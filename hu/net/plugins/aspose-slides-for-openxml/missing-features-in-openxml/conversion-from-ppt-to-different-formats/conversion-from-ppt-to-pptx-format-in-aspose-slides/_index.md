---
title: Átalakítás PPT formátumból PPTX formátumba az Aspose.Slides-ban
type: docs
weight: 10
url: /hu/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET most már lehetővé teszi a fejlesztők számára, hogy a PPT-t a Presentation osztály példányával érjék el, és azt a megfelelő PPTX formátumba konvertálják. Jelenleg részleges PPT-ről PPTX-re konverziót támogat. A PPT-ről PPTX-re konverzió támogatott és nem támogatott funkcióiról további részletekért kérjük, tekintse meg a dokumentációs hivatkozást.

**Aspose.Slides** for .NET egy Presentation osztályt kínál, amely egy PPTX prezentációs fájlt képvisel. A Presentation osztály most már a példányosítás során a PPT-t is elérheti a Presentation segítségével.

``` csharp

 //Hozzon létre egy Presentation objektumot, amely egy PPTX fájlt képvisel

PresentationEx pres = new PresentationEx("Conversion.ppt");

//A PPTX prezentáció mentése PPTX formátumba

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);
``` 
## **Minta kód letöltése**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)