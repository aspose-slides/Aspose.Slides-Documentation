---
title: ActiveX vezérlők kezelése prezentációkban Java használatával
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
- médiavégző
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Java az ActiveX-et a PowerPoint‑prezentációk automatizálásához és fejlesztéséhez, erőteljes vezérlést biztosítva a fejlesztőknek a diák felett."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for Java lehetővé teszi az ActiveX vezérlők hozzáadását és kezelését, de ezek a szokásos prezentációs alakzatokhoz képest kicsit bonyolultabbak. Beépítettük a Media Player Active vezérlő hozzáadásának támogatását az Aspose.Slides-be. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/). Ehelyett a különálló [IControlCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrolcollection/) részei. Ebben a témában megmutatjuk, hogyan dolgozhat velük. 

## **Media Player ActiveX vezérlő hozzáadása egy diára**
Az ActiveX Media Player vezérlő hozzáadásához a következőket kell tenni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztály példányt, és generáljon egy üres prezentációt.
2. Hozzáférés a cél diához a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) segítségével.
3. Adja hozzá a Media Player ActiveX vezérlőt a [addControl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) metódus használatával, amelyet az [IControlCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrolcollection/) biztosít.
4. Hozzáférés a Media Player ActiveX vezérlőhöz, és a videó útvonal beállítása a tulajdonságain keresztül.
5. Mentse a prezentációt PPTX fájlként.

Ez a mintakód, a fentiek alapján, bemutatja, hogyan adhat Media Player ActiveX vezérlőt egy diához:

```java
// Üres prezentációpéldány létrehozása
Presentation pres = new Presentation();
try {
    // A Media Player ActiveX vezérlő hozzáadása
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

Az Aspose.Slides for Java 7.1.0 és újabb verziók komponensekkel vannak ellátva az ActiveX vezérlők kezeléséhez. Elérheti a már hozzáadott ActiveX vezérlőt a prezentációban, és módosíthatja vagy törölheti a tulajdonságai segítségével.

{{% /alert %}} 

Egyszerű ActiveX vezérlő, például szövegdoboz és egyszerű parancsgomb kezelése egy dián a következő:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztály példányt, és töltse be a prezentációt, amelyben ActiveX vezérlők vannak.
2. Szerezzen be egy diára hivatkozást az indexe alapján.
3. Hozzáférés a dián lévő ActiveX vezérlőkhöz a [IControlCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrolcollection/) elérésével.
4. Hozzáférés a TextBox1 ActiveX vezérlőhöz a [IControl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icontrol/) objektum használatával.
5. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, amelyek a szöveget, betűtípust, betűméretet és a keret pozícióját tartalmazzák.
6. Hozzáférés a második vezérlőhöz, amely CommandButton1 néven ismert.
7. Módosítsa a gomb feliratát, betűtípusát és pozícióját.
8. Módosítsa az ActiveX vezérlők keretének helyzetét.
9. Írja a módosított prezentációt PPTX fájlba.

Ez a mintakód, a fenti lépések alapján, bemutatja, hogyan kezelhet egy egyszerű ActiveX vezérlőt: 

```java
// ActiveX vezérlőket tartalmazó prezentáció elérése
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // A prezentáció első diájának elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox szövegének módosítása
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Helyettesítő kép módosítása. A PowerPoint ezt a képet az ActiveX aktiválásakor lecseréli,
        // ezért néha elfogadható a kép változatlanul hagyása.
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

    // Gombfelirat módosítása
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
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **GYIK**

**Az Aspose.Slides megőrzi az ActiveX vezérlőket olvasás és újramentés során, ha azok nem hajthatók végre a Java runtime környezetben?**

Igen. Az Aspose.Slides ezeket a prezentáció részének tekinti, és képes olvasni/módosítani a tulajdonságaikat és kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, kezelt vezérlők (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/java/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Ezek eltérő módon tárolódnak és kezelődnek, valamint különböző tulajdonságmodellel rendelkeznek.

**Működnek az ActiveX események és a VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megtartja a meglévő jelölőnyelvet és metaadatokat; azonban az események és a makrók csak Windows-on a PowerPoint-on futnak, ha a biztonsági beállítások engedélyezik. A könyvtár nem hajtja végre a VBA‑t.