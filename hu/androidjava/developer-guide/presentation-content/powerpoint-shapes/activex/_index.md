---
title: ActiveX vezérlők kezelése prezentációkban Androidon
linktitle: ActiveX
type: docs
weight: 80
url: /hu/androidjava/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Android via Java az ActiveX-et a PowerPoint prezentációk automatizálásához és fejlesztéséhez, lehetővé téve a fejlesztők számára a diák erőteljes irányítását."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for Android via Java lehetővé teszi az ActiveX vezérlők hozzáadását és kezelését, de ezek kicsit nehezebben kezelhetők a normál prezentációs alakzatokhoz képest. Az Aspose.Slidesben bevezettük a Media Player Active vezérlő hozzáadásának támogatását. Fontos megjegyezni, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/). Ehelyett a különálló [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) részei. Ebben a témában megmutatjuk, hogyan dolgozhat velük.

## **Media Player ActiveX vezérlő hozzáadása diára**
Az ActiveX Media Player vezérlő hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és generáljon egy üres prezentációt.  
1. Hozzáférés a céldiarhoz a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályban.  
1. Adja hozzá a Media Player ActiveX vezérlőt a [addControl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) metódus segítségével, amely a [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) osztályban érhető el.  
1. Hozzáfér a Media Player ActiveX vezérlőhöz, és állítsa be a videó útvonalát a tulajdonságainak használatával.  
1. Mentse a prezentációt PPTX fájlként.

Az alábbi példakód, a fenti lépések alapján, bemutatja, hogyan adhat hozzá Media Player ActiveX vezérlőt egy diára:

```java
import com.aspose.slides.*;

// Üres prezentáció példány létrehozása
Presentation pres = new Presentation();
try {
    // Media Player ActiveX vezérlő hozzáadása
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // A Media Player ActiveX vezérlő elérése és a videó útvonal beállítása
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // A prezentáció mentése
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX vezérlő módosítása**
{{% alert color="info" %}} 

Az Aspose.Slides for Android via Java 7.1.0 és az annál újabb verziók komponensekkel rendelkeznek az ActiveX vezérlők kezelésére. Elérheti a már hozzáadott ActiveX vezérlőt a prezentációjában, és módosíthatja vagy törölheti a tulajdonságain keresztül. 

{{% /alert %}} 

Egyszerű ActiveX vezérlő, például szövegdoboz vagy egyszerű parancsgomb kezelése egy dián a következőképpen történik:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt, amelyben ActiveX vezérlők találhatók.  
1. Szerezze be a diára való hivatkozást az index alapján.  
1. A dián lévő ActiveX vezérlőkhöz férjen hozzá a [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) segítségével.  
1. A TextBox1 ActiveX vezérlőhöz a [IControl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrol/) objektum használatával férjen hozzá.  
1. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, beleértve a szöveget, a betűtípust, a betűméretet és a keret pozícióját.  
1. Férjen hozzá a második vezérlőhöz, amely a CommandButton1.  
1. Módosítsa a gomb feliratát, a betűtípust és a pozíciót.  
1. Módosítsa az ActiveX vezérlők kereteinek pozícióját.  
1. Írja a módosított prezentációt PPTX fájlba.  

Az alábbi példakód, a fenti lépések alapján, bemutatja, hogyan kezelhet egyszerű ActiveX vezérlőt: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// A ActiveX vezérlőkkel rendelkező prezentáció elérése
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // A prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Szövegdoboz szövegének módosítása
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // A helyettesítő kép módosítása. A PowerPoint az activeX aktiválásakor kicseréli ezt a képet,
        // így néha rendben van a képet változatlanul hagyni.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Gomb feliratának módosítása
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);

        // A helyettesítő módosítása
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 100 ponttal lejjebb mozgatás
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // vezérlők eltávolítása
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Megőrzi-e az Aspose.Slides az ActiveX vezérlőket olvasáskor és újramentéskor, ha azok nem futtathatók a Java futtatókörnyezetben?

Igen. Az Aspose.Slides ezeket a prezentáció részének tekinti, és képes beolvasni/módosítani a tulajdonságaikat és a kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

### Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?

Az ActiveX vezérlők interaktív, menedzselt vezérlők (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/androidjava/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Ezeket másként tárolják és kezelik, és különböző tulajdonságmodellel rendelkeznek.

### Működnek-e az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?

Az Aspose.Slides megőrzi a meglévő jelölést és metaadatokat; azonban az események és makrók csak a Windows PowerPointban futnak, amennyiben a biztonsági beállítások engedélyezik. A könyvtár nem hajtja végre a VBA‑t.