---
title: Prezentációk konvertálása HTML5-re Java-ban
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása reszponzív HTML5-re az Aspose.Slides for Java-val. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók a PowerPoint‑prezentációk HTML5-re az Aspose.Slides segítségével. Kitér az egyszerű HTML5‑exportálásra webkiterjesztések vagy további függőségek nélkül, valamint a formaanimációk és diavetítési áttűnések vezérlésére szolgáló opciókra. A cikk bemutatja a szokásos PowerPoint‑HTML exportálási folyamatot, elmagyarázza, hogyan állítható elő HTML5‑kimenet dianézet módban, és azt, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a layout beállításával.

## **PowerPoint exportálása HTML5-re**

Ez a Java‑kód megmutatja, hogyan exportálhatsz egy prezentációt HTML5-re webkiterjesztések és függőségek nélkül:

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
Ebben az esetben tiszta HTML-t kapsz. 
{{% /alert %}}

Itt megadhatod a formaanimációk és diavetítési áttűnések beállításait:

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

## **PowerPoint exportálása HTML-re**

Ez a Java‑kód bemutatja a szokásos PowerPoint‑HTML exportálási folyamatot:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Ebben az esetben a prezentáció tartalma SVG‑ként kerül megjelenítésre a következő módon:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Megjegyzés" color="warning" %}} 
Ha ezt a módszert használod a PowerPoint HTML‑re exportálásához, az SVG renderelés miatt nem tudsz stílusokat alkalmazni vagy egyes elemeket animálni. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálj, amelyben a diák dianézet módban jelennek meg. Ebben az esetben, amikor a létrejött HTML5‑fájlt egy böngészőben megnyitod, a prezentáció dianézetben látható egy weboldalon.

Ez a Java‑kód bemutatja a PowerPoint‑HTML5 dianézet exportálási folyamatát:

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

## **Prezentációk konvertálása HTML5 dokumentumokká megjegyzésekkel**

A PowerPoint‑megjegyzések olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy megjegyzéseket vagy visszajelzéseket hagyjanak a diákon. Különösen hasznosak együttműködési projektekben, ahol több személy is hozzáadhat javaslatokat vagy megjegyzéseket adott diaelemekhez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés tartalmazza a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció a „sample.pptx” fájlban van elmentve.

![Two comments on the presentation slide](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertálsz, könnyen megadhatod, hogy a megjegyzések szerepeljenek‑e a kimeneti dokumentumban. Ehhez add át a megjegyzések megjelenítési paramétereit a `setSlidesLayoutOptions` metódusnak a [Html5Options](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/) osztályon.

Az alábbi kódrészlet egy prezentációt konvertál HTML5 dokumentummá, a megjegyzésekkel a diák jobb oldalán megjelenítve.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Az „output.html” dokumentum az alábbi képen látható.

![The comments in the output HTML5 document](two_comments_html5.png)

## **GYIK**

### Korlátozhatom-e, hogy az objektumanimációk és diák áttűnései lejátszódjanak HTML5-ben?

Igen, a HTML5 külön opciókat biztosít a [shape animations](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [slide transitions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.

### Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diahoz képest?

Igen, a megjegyzések hozzáadhatók a HTML5-hez, és elhelyezhetők (például a dia jobb oldalán) a [layout settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) segítségével a jegyzetek és megjegyzések számára.

### Kihagyhatok-e JavaScript-et hívó linkeket biztonsági vagy CSP okokból?

Igen, létezik egy [setting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), amely lehetővé teszi a JavaScript‑hívású hiperhivatkozások kihagyását mentéskor. Ez segít a szigorú biztonsági szabályzatok betartásában.