use SmartShop


Select 0 'Sr' ,proID, ImeProizvoda 'Ime Proizvoda' , b.ImeBrenda 'Brend', c.ImeBoje, Ram, Memorija, Cena from tblProduct p
inner join tblColor c on c.BojaID = p.colorID
inner join tblBrand b on b.brandID = p.brandID