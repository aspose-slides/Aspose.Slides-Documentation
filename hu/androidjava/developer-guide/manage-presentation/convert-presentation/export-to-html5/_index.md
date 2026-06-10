---
title: Prezentációk konvertálása HTML5-re Androidon
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/androidjava/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- prezentáció HTML5-re
- dia HTML5-re
- PPT HTML5-re
- PPTX HTML5-re
- ODP HTML5-re
- PPT mentése HTML5-ként
- PPTX mentése HTML5-ként
- ODP mentése HTML5-ként
- PPT exportálása HTML5-be
- PPTX exportálása HTML5-be
- ODP exportálása HTML5-be
- Android
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása reszponzív HTML5-re az Aspose.Slides for Android segítségével Java-ban. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat HTML5-re konvertálni az Aspose.Slides használatával. Lefedi az egyszerű HTML5‑exportálást webes kiterjesztések vagy további függőségek nélkül, valamint a formaanimációk és diaváltások vezérlésének beállítási lehetőségeit. A cikk továbbá megmutatja a szokásos PowerPoint‑HTML exportfolyamatot, ismerteti, hogyan lehet HTML5‑kimenetet dianézetben előállítani, és bemutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba az elrendezés konfigurálásával.

## **PowerPoint exportálása HTML5-re**

Ez a Java kód azt mutatja, hogyan lehet egy prezentációt HTML5-re exportálni webes kiterjesztések és függőségek nélkül:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Ebben az esetben tiszta HTML-t kap. 
{{% /alert %}}

Így is megadhatja a formaanimációk és diaváltások beállításait:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint exportálása HTML-re**

Ez a Java bemutatja a szokásos PowerPoint‑HTML exportfolyamatot:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Ebben az esetben a prezentáció tartalma SVG‑vel kerül megjelenítésre a következő módon:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Ha ezt a módszert használja a PowerPoint HTML‑exportálásához, az SVG renderelés miatt nem lesz lehetőség stílusok alkalmazására vagy adott elemek animálására. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertáljon, amelyben a diák dianézetben jelennek meg. Ebben az esetben, amikor a keletkezett HTML5‑fájlt a böngészőben megnyitja, a prezentációt dianézetben láthatja a weboldalon. 

Ez a Java kód bemutatja a PowerPoint‑HTML5 dia nézet exportfolyamatát:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bemutató konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint‑megjegyzések egy eszköz, amely lehetővé teszi a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a diákon. Különösen hasznosak együttműködési projektekben, ahol több személy adhat hozzá javaslatokat vagy megjegyzéseket a diák egyes elemeihez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés megjeleníti a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést. 

Tegyük fel, hogy a következő PowerPoint‑prezentáció a "sample.pptx" fájlban van elmentve.

![Két megjegyzés a prezentációs dián](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertál, egyszerűen megadhatja, hogy a prezentációból származó megjegyzéseket bele szeretné-e foglalni a kimeneti dokumentumba. Ehhez meg kell adnia a megjegyzések megjelenítési paramétereit a `getNotesCommentsLayouting` metódusban a [Html5Options](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/) osztályban.

A következő kódrészlet egy prezentációt konvertál HTML5 dokumentummá, a megjegyzésekkel, amelyek a diák jobb oldalán jelennek meg.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

A "output.html" dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **FAQ**

**Szabályozhatom, hogy az objektumanimációk és diaváltások lejátszásra kerüljenek HTML5-ben?**  

Igen, a HTML5 különálló beállításokat kínál a [formaanimációk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [diaváltások](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.  

**Támogatott a megjegyzések kimenete, és hol helyezhetők el a diához képest?**  

Igen, a megjegyzések hozzáadhatók HTML5-ben, és elhelyezhetők (például a dia jobb oldalán) a [layout beállításokon](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) keresztül a jegyzetek és megjegyzések számára.  

**Kihagyhatom-e a JavaScript‑et hívó hivatkozásokat biztonsági vagy CSP‑okból adódó okok miatt?**  

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), amely lehetővé teszi, hogy a mentés során kihagyja a JavaScript‑hívásokat tartalmazó hiperhivatkozásokat. Ez segít a szigorú biztonsági szabályzatok betartásában.