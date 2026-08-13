---
title: PowerPoint-prezentációk konvertálása animált GIF-ekre Androidon
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
  - egyéni beállítások
  - PowerPoint
  - prezentáció
  - Android
  - Java
  - Aspose.Slides
description: "Könnyedén konvertálja a PowerPoint-prezentációkat (PPT, PPTX) animált GIF-ekre az Aspose.Slides for Android segítségével Java nyelven. Gyors, magas minőségű eredmények."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy néhány sor kóddal PowerPoint‑prezentációkat animált GIF‑fájlokká konvertáljon. Ez akkor hasznos, amikor a diáktartalmat könnyű, széles körben támogatott animált formátumban kell megosztani, amely beágyazható weboldalakba, üzenetküldő alkalmazásokba vagy dokumentációba. Ez a cikk bemutatja, hogyan exportáljon egy prezentációt GIF‑be alapértelmezett beállításokkal, valamint hogyan testreszabja a kimenetet a keretméret, diakésleltetés és átmeneti képkocka‑arány beállításával a [GifOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/gifoptions/) segítségével.

## **Prezentációk konvertálása animált GIF-re alapértelmezett beállításokkal**

Ez a Java‑mintakód azt mutatja, hogyan konvertáljon egy prezentációt animált GIF‑re szabványos beállításokkal:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Az animált GIF alapértelmezett paraméterekkel lesz létrehozva. 

{{%  alert  title="TIP"  color="info"  %}} 
Ha inkább testre szabná a GIF paramétereit, használja a [GifOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GifOptions) osztályt. Tekintse meg az alábbi mintakódot. 
{{% /alert %}} 

## **Prezentációk konvertálása animált GIF-re egyéni beállításokkal**

Ez a mintakód azt mutatja, hogyan konvertáljon egy prezentációt animált GIF‑re egyéni beállításokkal Java‑ban:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // a létrehozott GIF mérete
	gifOptions.setDefaultDelay(2000); // mennyi ideig jelenik meg egy dia, amíg a következőre vált
	gifOptions.setTransitionFps(35); // növelje az FPS-t a jobb átmeneti animáció minőségért
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Érdemes kipróbálni az Aspose által fejlesztett INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertert. 
{{% /alert %}}

## **GYIK**

### Mi a teendő, ha a prezentációban használt betűtípusok nincsenek telepítve a rendszeren?

Telepítse a hiányzó betűtípusokat vagy [konfigurálja a helyettesítő betűtípusokat](/slides/hu/androidjava/powerpoint-fonts/). Az Aspose.Slides helyettesíti őket, de a megjelenés eltérhet. Márkaépítés esetén mindig győződjön meg arról, hogy a szükséges betűkészletek kifejezetten elérhetők.

### Hozzáadhatok vízjelet a GIF‑képkockákhoz?

Igen. [Adjon hozzá félig átlátszó objektumot/logót](/slides/hu/androidjava/watermark/) a mesterdiához vagy az egyes diákhoz exportálás előtt – a vízjel minden képkockán megjelenik.