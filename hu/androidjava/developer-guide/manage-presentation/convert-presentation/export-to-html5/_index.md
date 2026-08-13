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
- PPT exportálása HTML5-re
- PPTX exportálása HTML5-re
- ODP exportálása HTML5-re
- Android
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-be az Aspose.Slides for Android segítségével Java nyelven. Őrizze meg a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhat PowerPoint‑prezentációkat HTML5‑re az Aspose.Slides használatával. Kitér az egyszerű HTML5‑exportálásra webes kiegészítők vagy további függőségek nélkül, valamint a formaanimációk és diaátmenetek vezérlésének lehetőségeire. A cikk ismerteti a szokásos PowerPoint‑HTML exportfolyamatait, bemutatja, hogyan generálhat HTML5‑kimenetet dia‑nézet módban, és megmutatja, hogyan lehet megjegyzéseket felvenni az exportált dokumentumba a layout beállításával.

## **PowerPoint exportálása HTML5‑be**

Ez a Java‑kód azt mutatja, hogyan exportálhat egy prezentációt HTML5‑be webes kiegészítők és függőségek nélkül:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Ebben az esetben tiszta HTML-et kap. 
{{% /alert %}}

A formaanimációk és diaátmenetek beállításait így adhatja meg:

```java
import com.aspose.slides.*;

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

## **PowerPoint exportálása HTML‑be**

Ez a Java‑példa a szokásos PowerPoint‑HTML folyamatot mutatja be:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Ebben az esetben a prezentáció tartalma SVG‑ként kerül renderelésre, a következő alakban:

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
Ha ezzel a módszerrel exportálja a PowerPointot HTML‑be, az SVG renderelés miatt nem tud stílusokat alkalmazni vagy animálni bizonyos elemeket. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 Dia‑nézetben**

**Aspose.Slides** lehetővé teszi, hogy a PowerPoint‑prezentációt HTML5‑dokumentummá konvertálja, ahol a diák dia‑nézet módban jelennek meg. Ebben az esetben, ha a létrejött HTML5‑fájlt böngészőben megnyitja, a prezentációt weboldalon dia‑nézetben láthatja.

Ez a Java‑kód bemutatja a PowerPoint‑HTML5 Dia‑nézet exportfolyamatát:

```java
import com.aspose.slides.*;

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

## **Prezentáció konvertálása HTML5‑dokumentummá megjegyzésekkel**

A PowerPoint‑megjegyzések olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a diákon. Különösen együttműködő projektekben hasznosak, ahol több személy adhat hozzá javaslatokat vagy megjegyzéseket a konkrét diák elemeihez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés tartalmazza a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció a „sample.pptx” fájlban van mentve.

![Two comments on the presentation slide](two_comments_pptx.png)

Amikor a PowerPoint‑prezentációt HTML5‑dokumentummá konvertálja, egyszerűen megadhatja, hogy a kimeneti dokumentumban megjelenjenek‑e a prezentáció megjegyzései. Ehhez át kell adnia a megjegyzések megjelenítési paramétereit a `setSlidesLayoutOptions` metódusnak a [Html5Options](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/) osztályból.

Az alábbi kódrészlet egy prezentációt HTML5‑dokumentummá konvertál, a megjegyzésekkel a diák jobb oldalán megjelenítve.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Az „output.html” dokumentum az alábbi képen látható.

![The comments in the output HTML5 document](two_comments_html5.png)

## **GYIK**

### Kezelhetem, hogy az objektumanimációk és diaátmenetek lejátszódjanak HTML5‑ben?

Igen, a HTML5 külön beállításokat biztosít a [alak animációk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [diaátmenetek](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezéséhez vagy letiltásához.

### Támogatottak a megjegyzések kimenete, és hol helyezhetők el a diához képest?

Igen, a megjegyzések hozzáadhatók HTML5‑ben, és a [layout beállítások](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) segítségével (például a dia jobb oldalára) helyezhetők el.

### Kihagyhatom-e azokat a hivatkozásokat, amelyek JavaScriptet hívnak meg a biztonság vagy CSP okokból?

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), amely lehetővé teszi a JavaScript‑hívásokat tartalmazó hiperhivatkozások kihagyását mentéskor. Ez segít a szigorú biztonságpolitikai előírások betartásában.