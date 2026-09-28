---
title: Aspose.Slides értékelése
type: docs
weight: 75
url: /hu/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides kiértékelése
- Aspose.Slides értékelés
- értékelő verzió
- teljes funkcionalitás
- értékelő vízjel
- Aspose.Slides vásárlása
- korlátozás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Értékelje az Aspose.Slides-t .NET-re, és ismerje meg az API funkciókat a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkhoz—kezdje el ingyenes próbaverzióját."
---
## **Aspose.Slides értékelés**

Letöltheti az Aspose.Slides-t kiértékeléshez. Az értékelő csomag megegyezik a megvásárolt csomaggal; licencelté lesz, miután néhány kódsort hozzáad a licenc alkalmazásához.

Licenc nélkül az Aspose.Slides teljes funkcionalitását biztosítja értékelő módban, két korláttal: minden mentett prezentáció minden diájához hozzáad egy értékelő vízjel szövegdobozt, és a kódból egy prezentációból olvasott szöveget az első néhány karakterre csonkolja, amelyet egy értesítés követ a kiértékelési korlátról. A kód által írt szöveg teljesen mentésre kerül.

![Dia az értékelő vízjellel](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Ha az Aspose.Slides-t az értékelő verzió korlátozása nélkül szeretné tesztelni, kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [Hogyan kérhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Az értékelő csomag telepítése**

```bash
dotnet add package Aspose.Slides.NET
```

Linuxon és macOS-en a helyette az Aspose.Slides.NET6.CrossPlatform csomagot használhatja; lásd a [Telepítés](/slides/hu/net/installation/) részt.

## **Licenc alkalmazása**

Ezek a „néhány kódsor”, amelyek az értékelő csomagot licencszerűvé alakítják. Alkalmazza a licencet egyszer az alkalmazás indításakor, mielőtt bármely `Presentation` objektum létrejönne — egy korábban létrehozott prezentáció megőrzi az értékelő vízjelet.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

A `SetLicense` egy `Stream`-et is elfogad, ami jobb megoldás, ha a licenc beágyazott erőforrásként kerül szállításra, a lemezen lévő fájl helyett. Ha az útvonal hibás vagy a fájl lejárt, a hívás kivételt dob, így a hibák azonnal az indításkor felszínre kerülnek ahelyett, hogy csendben az értékelő módba váltanának.

Miután a licencet alkalmazták, a mentett prezentációk már nem tartalmazzák a vízjelet, és a szöveget teljes egészében olvassák.

## **GYIK**

### Tesztelhetek több prezentációt párhuzamosan különböző szálakon értékelő módban?

Igen. Különböző dokumentumokat párhuzamosan feldolgozhat; nem szabad ugyanazt a prezentáció objektumot megosztani [szálak között](/slides/hu/net/multithreading/). Az értékelő mód nem befolyásolja ezt.

### Szükséges-e a Microsoft PowerPoint telepítése a könyvtár értékeléséhez egy szerveren vagy CI-ben?

Nem. Az Aspose.Slides egy önálló motor, és sem értékeléshez, sem termeléshez nem igényel PowerPoint telepítést.

### Tesztelhetem teljesen a PPT/PPTX PDF- és képekre konvertálását értékelő módban?

Igen. A [konvertálók](/slides/hu/net/convert-presentation/) működnek; a kimenet vízjelet tartalmaz majd.

### Használhatok ideiglenes licencet terhelésvizsgálatra vízjel nélkül?

Igen. Egy 30 napos ideiglenes licenc eltávolítja az értékelő mód korlátozásait, és lehetővé teszi a tesztelést vízjel nélkül.