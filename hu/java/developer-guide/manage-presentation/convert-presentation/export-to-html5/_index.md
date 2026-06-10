---
title: Prezentációk HTML5-re konvertálása Java-ban
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
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for Java segítségével. Megőrzi a formátumot, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat HTML5-re konvertálni az Aspose.Slides használatával. Lefedi az alapvető HTML5‑exportálást webbővítmények vagy további függőségek nélkül, valamint a formaanimációk és diaváltások vezérlésének beállítási lehetőségeit. A cikk továbbá megmutatja a szabványos PowerPoint‑HTML export folyamatát, elmagyarázza, hogyan lehet HTML5‑kimenetet előállítani dianézet módban, és bemutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a elrendezésük konfigurálásával.

## **PowerPoint exportálása HTML5-re**

Ez a Java kód bemutatja, hogyan lehet egy prezentációt HTML5-re exportálni webbővítmények és függőségek nélkül:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Ebben az esetben tiszta HTML-t kapunk. 
{{% /alert %}}

Ily módon megadhatja a formaanimációk és diaváltások beállításait:

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

Ez a Java példa a szabványos PowerPoint‑HTML folyamatot mutatja be:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Ebben az esetben a prezentáció tartalma SVG‑vel van renderelve, a következő módon:

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
Ha ezt a módszert használja a PowerPoint HTML‑re exportálásához, az SVG renderelés miatt nem lesz lehetőség stílusok alkalmazására vagy meghatározott elemek animálására. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá alakítson, amelyben a diák dianézet módban jelennek meg. Ebben az esetben, amikor a keletkezett HTML5 fájlt megnyitja egy böngészőben, a prezentációt dianézetben látja a weboldalon. 

Ez a Java kód bemutatja a PowerPoint‑HTML5 dianézet export folyamatát:

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

## **Prezentációk konvertálása HTML5 dokumentumokká megjegyzésekkel**

A PowerPoint megjegyzései egy olyan eszköz, amely lehetővé teszi a felhasználók számára, hogy megjegyzéseket vagy visszajelzéseket hagyjanak a prezentációs diákon. Különösen hasznosak együttműködéses projektekben, ahol több ember adhat hozzá javaslatokat vagy észrevételeket a diák egyes elemeihez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés mutatja a szerző nevét, így könnyű nyomon követni, ki tette a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentáció a "sample.pptx" fájlban van elmentve.

![Két megjegyzés a prezentációs dián](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertál, egyszerűen megadhatja, hogy a megjegyzéseket bele szeretné-e foglalni a kimeneti dokumentumba. Ehhez meg kell adnia a megjegyzések megjelenítési paramétereit a `getNotesCommentsLayouting` metódusban a [Html5Options](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/) osztályon.

A következő kódrészlet egy prezentációt HTML5 dokumentummá konvertál, a megjegyzésekkel a diák jobb oldalán.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések az output HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Ellenőrizhetem, hogy az objektumanimációk és diaváltások lejátszódnak-e HTML5-ben?**  
Igen, a HTML5 külön beállításokat kínál a [formaanimációk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és a [diaváltások](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) engedélyezésére vagy letiltására.

**Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a dia viszonylatában?**  
Igen, a megjegyzések hozzáadhatók HTML5-ben, és elhelyezhetők (például a dia jobb oldalára) a [elrendezési beállításokon](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) keresztül a jegyzetek és megjegyzések számára.

**Kihagyhatok JavaScript‑hívó hivatkozásokat biztonsági vagy CSP‑okozatok miatt?**  
Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), amely lehetővé teszi a JavaScript‑hívásokat tartalmazó hiperhivatkozások kihagyását mentéskor. Ez segít a szigorú biztonsági szabályok betartásában.