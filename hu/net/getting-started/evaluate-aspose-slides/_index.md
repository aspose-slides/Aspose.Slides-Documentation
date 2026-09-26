---
title: Aspose.Slides értékelése
type: docs
weight: 120
url: /hu/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides értékelése
- Aspose.Slides értékelése
- értékelő verzió
- teljes funkcionalitás
- értékelési vízjel
- Aspose.Slides vásárlása
- korlátozás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Értékelje az Aspose.Slides-t .NET-hez, és ismerje meg a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációk API funkcióit – indítsa el ingyenes próbaidőszakát."
---
## **Aspose.Slides értékelés**

Az Aspose.Slides értékeléshez letölthető. Az értékelési csomag megegyezik a megvásárolt csomaggal; licenccé válik, miután néhány kódsort hozzáadunk a licenc alkalmazásához.

Licenc nélkül az Aspose.Slides teljes funkcionalitását biztosítja értékelési módban, két korláttal: minden mentett prezentáció minden diájára egy értékelési vízjel szövegdobozot helyez, és a kódja által egy prezentációból olvasott szöveg az első néhány karakterre van csonkolva, amit egy az értékelésre vonatkozó értesítés követ. A kód által írt szöveg teljes egészében mentésre kerül.

![Dia az értékelési vízjellel](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Ha az Aspose.Slides-t az értékelési verzió korlátozása nélkül szeretné tesztelni, kérhet egy **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan kérhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Az értékelési csomag telepítése**

```bash
dotnet add package Aspose.Slides.NET
```

Linuxon és macOS-en a Aspose.Slides.NET6.CrossPlatform csomagot használhatja helyette; lásd a [Telepítés](/slides/hu/net/installation/) részt.

## **Licenc alkalmazása**

Ezek azok a „néhány kódsor”, amelyek az értékelési csomagot licenccé alakítják. Alkalmazza a licencet egyszer az alkalmazás indításakor, még mielőtt bármilyen `Presentation` objektum létrejönne – egy korábban létrehozott prezentáció megtartja az értékelési vízjelet.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` egy `Stream`-et is elfogad, ami jobb megoldás, ha a licenc beágyazott erőforrásként kerül szállításra a lemezről való fájl helyett. Ha az útvonal hibás vagy a fájl lejárt, a hívás kivételt dob, így a hibák már az indításkor azonnal felszínre kerülnek ahelyett, hogy csendben visszatérnének az értékelési módba.

Miután a licenc alkalmazásra került, a mentett prezentációk már nem tartalmazzák a vízjelet, és a szöveg teljes egészében olvasható.

## **GYIK**

### Tesztelhetek több prezentációt párhuzamosan különböző szálakon értékelési módban?

Igen. Különböző dokumentumokat párhuzamosan feldolgozhat; nem szabad ugyanazt a prezentációobjektumot megosztani [szálak között](/slides/hu/net/multithreading/). Az értékelési mód erre nem hat.

### Szükséges-e a Microsoft PowerPoint telepítése a könyvtár értékeléséhez egy szerveren vagy CI környezetben?

Nem. Az Aspose.Slides egy önálló motor, amelyhez nem szükséges a PowerPoint telepítése sem értékeléshez, sem a termeléshez.

### Teljesen tesztelhetem a PPT/PPTX PDF-re és képekre konvertálását értékelési módban?

Igen. A [konverterek](/slides/hu/net/convert-presentation/) működnek; a kimenet vízjelet fog tartalmazni.

### Használhatok ideiglenes licencet terheléses teszteléshez vízjel nélkül?

Igen. Egy 30 napos ideiglenes licenc eltávolítja az értékelési mód korlátozásait, és lehetővé teszi a tesztelést vízjel nélkül.