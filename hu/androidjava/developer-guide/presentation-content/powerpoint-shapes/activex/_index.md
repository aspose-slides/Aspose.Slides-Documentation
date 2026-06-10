---
title: ActiveX vezérlők kezelése Android prezentációkban
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
- média lejátszó
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Android via Java az ActiveX-et a PowerPoint prezentációk automatizálására és fejlesztésére, lehetővé téve a fejlesztők számára a diák feletti hatékony irányítást."
---
## **Bevezetés**

ActiveX vezérlőket használnak a prezentációkban. Az Aspose.Slides for Android via Java lehetővé teszi ActiveX vezérlők hozzáadását és kezelését, de ezek kezelése valamivel bonyolultabb a normál prezentációs alakzatokhoz képest. Beépítettük a Media Player Active vezérlő hozzáadásának támogatását az Aspose.Slides-ben. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/). Inkább a különálló [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) részei. Ebben a témában megmutatjuk, hogyan dolgozhat velük.

## **Media Player ActiveX vezérlő hozzáadása egy diára**
A Media Player ActiveX vezérlő hozzáadásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és generáljon egy üres prezentáció példányt.  
1. Hozzáférés a cél diához a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályban.  
1. Adja hozzá a Media Player ActiveX vezérlőt a [addControl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) metódussal, amelyet a [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) biztosít.  
1. Hozzáférés a Media Player ActiveX vezérlőhöz, és állítsa be a videó útvonalát a tulajdonságai segítségével.  
1. Mentse a prezentációt PPTX fájlként.  

Ez a minta kód, a fenti lépések alapján, bemutatja, hogyan adhat hozzá Media Player ActiveX vezérlőt egy diához:

```java
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
{{% alert color="primary" %}} 

Az Aspose.Slides for Android via Java 7.1.0 és újabb verziók komponensekkel vannak felszerelve az ActiveX vezérlők kezeléséhez. Hozzáférhet a már hozzáadott ActiveX vezérlőhöz a prezentációban, és módosíthatja vagy törölheti a tulajdonságain keresztül. 

{{% /alert %}} 

Egyszerű ActiveX vezérlő, például egy szövegdoboz és egy egyszerű parancsgomb kezelése egy dián, tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a prezentációt, amely tartalmaz ActiveX vezérlőket.  
1. Szerezzen be egy dia hivatkozást az indexe alapján.  
1. Hozzáférés a dián lévő ActiveX vezérlőkhöz a [IControlCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrolcollection/) használatával.  
1. Hozzáférés a TextBox1 ActiveX vezérlőhöz a [IControl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icontrol/) objektum segítségével.  
1. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, beleértve a szöveget, betűtípust, betűmagasságot és a keret pozícióját.  
1. Hozzáférés a második vezérlőhöz, amely CommandButton1 néven szerepel.  
1. Módosítsa a gomb feliratát, betűtípust és pozíciót.  
1. Módosítsa az ActiveX vezérlők kereteinek pozícióját.  
1. Írja ki a módosított prezentációt PPTX fájlba.  

Ez a minta kód, a fenti lépések alapján, bemutatja, hogyan kezelhet egy egyszerű ActiveX vezérlőt: 

```java
// ActiveX vezérlőkkel rendelkező prezentáció elérése
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // A prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // a TextBox szövegének módosítása
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Helyettesítő kép módosítása. A PowerPoint a kép helyettesítését az ActiveX aktiválásakor végzi,
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
        // Helyettesítő módosítása
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

## **GYIK**

**Az Aspose.Slides megőrzi az ActiveX vezérlőket olvasás és újramentés során, ha azok nem hajthatók végre a Java futtatókörnyezetben?**  

Igen. Az Aspose.Slides a vezérlőket a prezentáció részének tekinti, és képes olvasni/módosítani a tulajdonságaikat és a kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megtartásukhoz.  

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**  

Az ActiveX vezérlők interaktív, kezelt vezérlők (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/androidjava/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Másképp tárolódnak és kezelődnek, és más tulajdonsági modelljük van.  

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**  

Az Aspose.Slides megőrzi a meglévő jelölőket és metaadatokat; azonban az események és makrók csak a Windows PowerPoint alkalmazásában futnak, ha a biztonsági beállítások engedélyezik. A könyvtár nem hajtja végre a VBA-t.