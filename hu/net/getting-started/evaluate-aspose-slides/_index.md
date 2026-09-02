---
title: Aspose.Slides értékelése
type: docs
weight: 120
url: /hu/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides értékelése
- Aspose.Slides értékelés
- értékelési verzió
- teljes funkcionalitás
- értékelési vízjel
- Aspose.Slides vásárlása
- korlátozás
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Értékelje az Aspose.Slides .NET verzióját, és ismerje meg a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációk API funkcióit - indítsa el ingyenes próbaidőszakát."
---
## **Aspose.Slides értékelés**

Az Aspose.Slides-t könnyedén letöltheti értékelés céljából. Az értékelési csomag megegyezik a megvásárolt csomaggal. Az értékelési verzió egyszerűen licencszerűvé válik, ha néhány sor kóddal alkalmazza a licencet. 

Az Aspose.Slides értékelési verziója (licenc megadása nélkül) teljes termékfunkciókat biztosít, de nyitáskor és mentéskor a dokumentum tetejére értékelési vízjelet helyez. A bemutató diák szövegének kinyerése során egy diára korlátozódik.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 

Ha korlátozások nélkül szeretné tesztelni az Aspose.Slides-t, kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) című oldalt.

{{% /alert %}}

## **Az értékelési csomag telepítése**

```bash
dotnet add package Aspose.Slides.NET
```

## **Licenc alkalmazása**

Ezek a „néhány sor kód”, amelyek az értékelési csomagot licencelté alakítják. A licencet egyszer alkalmazza az alkalmazás indításakor, mielőtt bármely `Presentation` objektum létrejön – egy korábban létrehozott bemutató megtartja az értékelési vízjelet.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` fogad egy `Stream`‑et is, ami jobb megoldás, ha a licenc beágyazott erőforrásként érkezik, nem pedig fájlként a lemezen. Ha az útvonal hibás vagy a fájl lejárt, a hívás kivételt dob, így a hibák az indításkor azonnal láthatók, ahelyett, hogy csendben visszatérnének az értékelési módba.

Miután a licencet alkalmazták, a vízjel eltűnik, és az egy diára korlátozott szövegkinyerés feloldódik.

## **GYIK**

### Tesztelhetek több bemutatót párhuzamosan különböző szálakon az értékelési módban?

Igen. Különböző dokumentumokat párhuzamosan feldolgozhat; nem szabad ugyanazt a prezentációobjektumot megosztani [szálak között](/slides/hu/net/multithreading/). Az értékelési mód erre nem vonatkozik.

### Szükséges a Microsoft PowerPoint telepítése a könyvtár értékeléséhez szerveren vagy CI környezetben?

Nem. Az Aspose.Slides egy önálló motor, és nem igényel PowerPoint telepítést sem értékeléshez, sem produkcióhoz.

### Teljesen tesztelhetem a PPT/PPTX PDF- és képképbe konvertálását értékelési módban?

Igen. A [konvertáló eszközök](/slides/hu/net/convert-presentation/) működnek; a kimenetben vízjel lesz.

### Használhatok ideiglenes licencet terheléses teszteléshez vízjel nélkül?

Igen. A 30 napos ideiglenes licenc eltávolítja az értékelési mód korlátozásait, és lehetővé teszi a tesztelést vízjel nélkül.