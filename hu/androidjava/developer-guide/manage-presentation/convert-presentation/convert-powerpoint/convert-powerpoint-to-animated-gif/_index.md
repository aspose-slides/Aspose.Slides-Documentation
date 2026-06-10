---
title: PowerPoint prezentációk konvertálása animált GIF-ekre Androidon
linktitle: PowerPoint GIF-re
type: docs
weight: 65
url: /hu/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- animált GIF
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint GIF-re
- prezentáció GIF-re
- dia GIF-re
- PPT GIF-re
- PPTX GIF-re
- PPT mentése GIF-ként
- PPTX mentése GIF-ként
- PPT exportálása GIF-ként
- PPTX exportálása GIF-ként
- alapértelmezett beállítások
- egyedi beállítások
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén konvertálhat PowerPoint prezentációkat (PPT, PPTX) animált GIF-ekre az Aspose.Slides Android verziójával Java-ban. Gyors, magas minőségű eredmények."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy PowerPoint‑prezentációkat animált GIF‑fájlokká konvertáljon néhány kódsorral. Ez akkor hasznos, ha a dia tartalmát könnyű, széles körben támogatott animált formátumban szeretné megosztani, amely beágyazható weboldalakba, üzenetküldő alkalmazásokba vagy dokumentációba. Ez a cikk bemutatja, hogyan exportálja a prezentációt GIF‑be az alapértelmezett beállításokkal, és hogyan testreszabja a kimenetet a képkockaméret, a dia késleltetés és az áttűnési frekvencia beállításával a [GifOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/gifoptions/) használatával.

## **Prezentációk konvertálása animált GIF‑be alapértelmezett beállításokkal**

Ez a Java mintakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑be a szabványos beállításokkal:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Az animált GIF az alapértelmezett paraméterekkel jön létre.

{{%  alert  title="TIPP"  color="primary"  %}} 

Ha testre szeretné szabni a GIF paramétereit, használja a [GifOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GifOptions) osztályt. Lásd az alábbi mintakódot.

{{% /alert %}} 

## **Prezentációk konvertálása animált GIF‑be egyedi beállításokkal**

Ez a mintakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑be egyedi beállításokkal Java‑ban:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // az eredményül kapott GIF mérete  
	gifOptions.setDefaultDelay(2000); // mennyi ideig lesz minden dia látható, amíg a következőre vált
	gifOptions.setTransitionFps(35); // növelje az FPS‑t a jobb átmeneti animáció minőségéért
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Érdemes megnézni az Aspose által fejlesztett INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertálót.

{{% /alert %}}

## **GYIK**

**Mi van, ha a prezentációban használt betűtípusok nincsenek telepítve a rendszeren?**

Telepítse a hiányzó betűtípusokat vagy [állítson be helyettesítő betűtípusokat](/slides/hu/androidjava/powerpoint-fonts/). Az Aspose.Slides helyettesíti őket, de a megjelenés eltérhet. Márkaépítés esetén mindig győződjön meg arról, hogy a szükséges betűkészletek kifejezetten elérhetők.

**Hozzáadhatok vízjelet a GIF képkockáihoz?**

Igen. [Adjon hozzá félig átlátszó objektumot/logo-t](/slides/hu/androidjava/watermark/) a mesterdiára vagy az egyes diákra exportálás előtt – a vízjel minden képkockán megjelenik.