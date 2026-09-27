---
title: Értékelje az Aspose.Slides-t
type: docs
weight: 130
url: /hu/java/evaluate-aspose-slides/
keywords:
- Az Aspose.Slides értékelése
- Aspose.Slides értékelés
- értékelő verzió
- teljes funkcionalitás
- értékelő vízjel
- Aspose.Slides megvásárlása
- korlát
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Értékelje az Aspose.Slides for Java terméket, és fedezze fel az API funkciókat PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkhoz — kezdje el ingyenes próbaverzióját."
---
## **Aspose.Slides kiértékelése**

Letöltheti az Aspose.Slides-t értékelés céljából. Az értékelő letöltés megegyezik a megvásárolt letöltéssel; a licenc alkalmazásához néhány kódsort hozzáadva licencelté válik.

Licenc nélkül az Aspose.Slides teljes funkcionalitását biztosítja értékelő módban, két korláttal: minden mentett prezentáció minden diájához hozzáad egy értékelő vízjel szövegmezőt, és a kódból az API-n keresztül olvasott szöveg, beleértve a legutóbb beállított szöveget is, csak az első néhány karakterre kerül csonkolásra, melyet egy értesítés követ az értékelési korlátról. A kód által írt szöveg pedig teljes egészében mentésre kerül. A [getPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationText-java.lang.String-int-) metódus, amely a teljes prezentáció betöltése nélkül nyeri ki a szöveget, csak az értékelő értesítéseket adja vissza, és nem a dia szövegét.

![Dia az értékelő vízjellel](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Megjegyzés" %}}
Ha az Aspose.Slides-t az értékelő verzió korlátozásai nélkül szeretné tesztelni, kérhet egy 30 napos ideiglenes licencet is. Lásd a [Hogyan kérhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **GYIK**

### Tesztelhetek több prezentációt párhuzamosan különböző szálakon az értékelő módban?
Igen. Különböző dokumentumokat feldolgozhat párhuzamosan; nem szabad ugyanazt a prezentációobjektumot [szálak között](/slides/hu/java/multithreading/) megosztani. Az értékelő mód nem befolyásolja ezt.

### Szükséges-e a Microsoft PowerPoint telepítése a könyvtár értékeléséhez szerveren vagy CI-ben?
Nem. Az Aspose.Slides egy önálló motor, és sem értékeléskor, sem éles működéskor nem igényli a PowerPoint telepítését.

### Teljesen tesztelhetem a PPT/PPTX PDF-re és képekre konvertálását értékelő módban?
Igen. A [konvertálók](/slides/hu/java/convert-presentation/) működnek; a kimenet vízjelet fog tartalmazni.

### Használhatok ideiglenes licencet terheléses teszteléshez vízjel nélkül?
Igen. Egy 30 napos ideiglenes licenc eltávolítja az értékelő mód korlátozásait, és lehetővé teszi a tesztelést vízjel nélkül.