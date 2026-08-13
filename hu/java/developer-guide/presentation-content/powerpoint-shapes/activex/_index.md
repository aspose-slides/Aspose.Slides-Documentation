---
title: ActiveX vezérlők kezelése prezentációkban Java-val
linktitle: ActiveX
type: docs
weight: 80
url: /hu/java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerkedjen meg azzal, hogyan használja az Aspose.Slides for Java az ActiveX-ot a PowerPoint prezentációk automatizálására és fejlesztésére, lehetővé téve a fejlesztők számára a diák erőteljes irányítását."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for Java lehetővé teszi az ActiveX vezérlők hozzáadását és kezelését, de ezek kezelése valamivel bonyolultabb a szokásos prezentációs alakzatokhoz képest. Támogatást valósítottunk meg a Media Player Active vezérlő hozzáadására az Aspose.Slides-ben. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció IShapeCollection gyűjteményének. Ehelyett a különálló IControlCollection részei. Ebben a témában megmutatjuk, hogyan dolgozhat velük. 

## **Media Player ActiveX vezérlő hozzáadása diára**
A Media Player ActiveX vezérlő hozzáadásához tegye a következőket:

1. Hozzon létre egy példányt a Presentation osztályból, és generáljon egy üres prezentációpéldányt.
1. Hozzáférjen a céldiához a Presentation-ben.
1. Adja hozzá a Media Player ActiveX vezérlőt az IControlCollection által biztosított addControl metódus használatával.
1. Hozzáfér a Media Player ActiveX vezérlőhöz, és állítsa be a videó útvonalát a tulajdonságai segítségével.
1. Mentse a prezentációt PPTX fájlként.

Ez a mintakód a fenti lépések alapján bemutatja, hogyan adjon Media Player ActiveX vezérlőt egy diára:

```java
import com.aspose.slides.*;

// Üres prezentációpéldány létrehozása
Presentation pres = new Presentation();
try {
    // Media Player ActiveX vezérlő hozzáadása
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Hozzáférés a Media Player ActiveX vezérlőhöz és a videó útvonal beállítása
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // A prezentáció mentése
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX vezérlő módosítása**
{{% alert color="info" %}} 

Az Aspose.Slides for Java 7.1.0 és annál újabb verziói rendelkeznek az ActiveX vezérlők kezeléséhez szükséges összetevőkkel. Hozzáférhet a már hozzáadott ActiveX vezérlőhöz a prezentációban, és módosíthatja vagy törölheti azt a tulajdonságain keresztül.

{{% /alert %}} 

Egy egyszerű ActiveX vezérlő, például szövegdoboz vagy egyszerű parancsgomb kezelése egy dián a következőképpen történik:

1. Hozzon létre egy példányt a Presentation osztályból, és töltse be a prezentációt, amely már tartalmaz ActiveX vezérlőket.
1. Szerezzen meg egy diára mutató hivatkozást az indexe alapján.
1. Hozzáférjen a dián lévő ActiveX vezérlőkhöz az IControlCollection elérésével.
1. A TextBox1 ActiveX vezérlőhöz az IControl objektum segítségével férhet hozzá.
1. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, amelyek közé tartozik a szöveg, a betűtípus, a betűméret és a keret pozíciója.
1. Hozzáfér a második vezérlőhöz, amelynek neve CommandButton1.
1. Módosítsa a gomb feliratát, betűtípusát és pozícióját.
1. Módosítsa az ActiveX vezérlők kereteinek pozícióját.
1. Írja a módosított prezentációt PPTX fájlba.

Ez a mintakód a fenti lépések alapján bemutatja, hogyan kezeljen egy egyszerű ActiveX vezérlőt: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// AktívX vezérlőkkel rendelkező prezentáció elérése
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox szövegének módosítása
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Helyettesítő kép módosítása. A PowerPoint a kép helyét kicseréli az ActiveX aktiválásakor,
        // ezért időnként rendben van, ha a képet változatlanul hagyjuk.
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
        // Helyettesítő kép módosítása
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

            // 100 ponttal lefelé mozgatás
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // vezérlők eltávolítása
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

### Megőrzi-e az Aspose.Slides az ActiveX vezérlőket olvasáskor és újbóli mentéskor, ha nem hajthatók végre a Java futtatókörnyezetben?

Igen. Az Aspose.Slides a vezérlőket a prezentáció részeként kezeli, és képes olvasni/módosítani a tulajdonságaikat és a kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

### Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?

Az ActiveX vezérlők interaktív, menedzselt vezérlők (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/java/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Másképp tárolódnak és kezelődnek, és eltérő tulajdonságmodellel rendelkeznek.

### Működnek-e az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?

Az Aspose.Slides megőrzi a meglévő jelölést és metaadatokat; azonban az események és makrók csak a Windows rendszeren működő PowerPointban futnak, ha a biztonsági beállítások engedélyezik. A könyvtár nem hajtja végre a VBA-t.