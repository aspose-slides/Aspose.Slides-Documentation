---
title: "Az Aspose.Slides értékelése"
type: docs
weight: 120
url: /hu/net/evaluate-aspose-slides/
keywords:
- "Aspose.Slides értékelése"
- "Aspose.Slides értékelés"
- "értékelési verzió"
- "teljes funkcionalitás"
- "értékelési vízjel"
- "Aspose.Slides vásárlása"
- "korlátozás"
- PowerPoint
- OpenDocument
- "prezentáció"
- .NET
- C#
- Aspose.Slides
description: "Értékelje az Aspose.Slides-t .NET-re, és fedezze fel az API funkciókat PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkhoz—kezdje el ingyenes próbaidőszakát."
---
## **Aspose.Slides Értékelés**

Az Aspose.Slides-t könnyedén letöltheti értékeléshez. Az értékelési csomag ugyanaz, mint a megvásárolt csomag. Az értékelési verzió egyszerűen licenccé válik, ha néhány sor kóddal alkalmazza a licencet.  

Az Aspose.Slides értékelési verziója (licenc megadása nélkül) teljes termékfunkcionalitást nyújt, de egy értékelési vízjelet szúr be a dokumentum tetejére megnyitáskor és mentéskor. Az előadások diáinak szövegének kinyerésekor egy diára van korlátozva.  

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
Ha az Aspose.Slides-t az értékelési verzió korlátozása nélkül szeretné tesztelni, kérhet egy **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan szerezhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt. 
{{% /alert %}}

## **Telepítse az Értékelési Csomagot**

```bash
dotnet add package Aspose.Slides.NET
```

## **Licenc Alkalmazása**

Ezek a „néhány sor kód”, amelyek az értékelési csomagot licenccé alakítják. A licence‑t egyszer alkalmazza az alkalmazás indításakor, mielőtt bármely `Presentation` objektum létrejönne — egy korábban létrehozott prezentáció megtartja az értékelési vízjelet.  

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` is also a `Stream` paramétert fogad, ami jobb megoldás, ha a licenc beágyazott erőforrásként kerül szállításra a lemezen lévő fájl helyett. Ha az útvonal hibás vagy a fájl lejárt, a hívás kivételt dob, így a hibák azonnal felülnéznek az indításkor, a csendes visszatérés helyett az értékelési módba.  

Miután a licenc alkalmazva van, a vízjel eltűnik, és az egy diás szövegkinyerési korlát feloldódik.  

## **GYIK**

### Tesztelhetek több prezentációt párhuzamosan különböző szálakon értékelési módban?

Igen. Különböző dokumentumokat dolgozhat fel párhuzamosan; nem szabad ugyanazt a prezentációobjektumot megosztani [szálak között](/slides/hu/net/multithreading/). Az értékelési mód erre nincs hatással.  

### Szükséges-e a Microsoft PowerPoint telepítése a könyvtár értékeléséhez szerveren vagy CI-ben?

Nem. Az Aspose.Slides egy önálló motor, és sem a értékeléshez, sem a produkcióhoz nem igényel telepített PowerPointot.  

### Teljesen tesztelhetem a PPT/PPTX PDF-re és képekre történő konverzióját értékelési módban?

Igen. A [konvertálók](/slides/hu/net/convert-presentation/) működnek; a kimenet vízjelet tartalmazni fog.  

### Használhatok ideiglenes licencet terheléses teszteléshez vízjel nélkül?

Igen. Egy 30 napos ideiglenes licenc eltávolítja az értékelési mód korlátozásait, és lehetővé teszi a tesztelést vízjel nélkül.