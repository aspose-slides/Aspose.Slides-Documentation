---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí Javy
linktitle: ActiveX
type: docs
weight: 80
url: /cs/java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro Javu využívá ActiveX k automatizaci a vylepšení PowerPoint prezentací, a poskytuje vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky jsou používány v prezentacích. Aspose.Slides for Java umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jsou o něco obtížnější na správu ve srovnání s běžnými tvary prezentace. Implementovali jsme podporu pro přidání ActiveX ovládacího prvku Media Player v Aspose.Slides. Všimněte si, že ActiveX ovládací prvky nejsou tvary; nejsou součástí [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/). Patří do samostatné [IControlCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrolcollection/) místo toho. V tomto tématu vám ukážeme, jak s nimi pracovat.

## **Přidání ActiveX Media Player ovládacího prvku do snímku**
Pro přidání ActiveX Media Player ovládacího prvku proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a vygenerujte prázdnou prezentaci.
1. Získejte cílový snímek v [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Přidejte Media Player ActiveX ovládací prvek pomocí metody [addControl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) vystavené rozhraním [IControlCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrolcollection/).
1. Získejte Media Player ActiveX ovládací prvek a nastavte cestu k videu pomocí jeho vlastností.
1. Uložte prezentaci jako soubor PPTX.

Tento ukázkový kód, založený na výše uvedených krocích, ukazuje, jak přidat Media Player ActiveX ovládací prvek do snímku:

```java
import com.aspose.slides.*;

// Vytvořte prázdnou instanci prezentace
Presentation pres = new Presentation();
try {
    // Přidání ActiveX ovládacího prvku Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Získejte přístup k ActiveX ovládacímu prvku Media Player a nastavte cestu k videu
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Uložte prezentaci
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Úprava ActiveX ovládacího prvku**
{{% alert color="info" %}} 
Aspose.Slides for Java 7.1.0 a novější verze jsou vybaveny komponentami pro správu ActiveX ovládacích prvků. Můžete získat již přidaný ActiveX ovládací prvek v prezentaci a upravit jej nebo smazat pomocí jeho vlastností.
{{% /alert %}} 

Pro správu jednoduchého ActiveX ovládacího prvku, jako je textové pole a jednoduché tlačítko příkazu na snímku, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a načtěte prezentaci s ActiveX ovládacími prvky.
1. Získejte odkaz na snímek podle jeho indexu.
1. Přistupujte k ActiveX ovládacím prvkům na snímku přes [IControlCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrolcollection/).
1. Získejte ActiveX ovládací prvek TextBox1 pomocí objektu [IControl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrol/).
1. Změňte vlastnosti ActiveX ovládacího prvku TextBox1, které zahrnují text, písmo, výšku písma a umístění rámce.
1. Přistupte k druhému ovládacímu prvku nazvanému CommandButton1.
1. Změňte popisek tlačítka, písmo a umístění.
1. Posuňte umístění rámců ActiveX ovládacích prvků.
1. Zapište upravenou prezentaci do souboru PPTX.

Tento ukázkový kód, založený na výše uvedených krocích, ukazuje, jak spravovat jednoduchý ActiveX ovládací prvek:

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Přístup k prezentaci s ActiveX ovládacími prvky
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Přístup k prvnímu snímku v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // mění se text TextBoxu
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Změna náhradního obrázku. PowerPoint tento obrázek nahradí během aktivace ActiveX,
        // takže je někdy v pořádku nechat obrázek beze změny.
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

    // Změna popisku tlačítka
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Změna náhrady
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

            // posunutí o 100 bodů dolů
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // odstraňování ovládacích prvků
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **Často kladené otázky**

### Zachovává Aspose.Slides ActiveX ovládací prvky při čtení a opětovném uložení, pokud nelze spustit v Java runtime?

Ano. Aspose.Slides s nimi zachází jako s částí prezentace a může číst/upravovat jejich vlastnosti a rámce; spuštění samotných ovládacích prvků není vyžadováno pro jejich zachování.

### Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?

ActiveX ovládací prvky jsou interaktivní řízené ovládací prvky (tlačítka, textová pole, přehrávač médií), zatímco [OLE](/slides/cs/java/manage-ole/) odkazuje na vložené aplikační objekty (například list Excelu). Jsou uloženy a zpracovávány odlišně a mají odlišné modely vlastností.

### Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?

Aspose.Slides zachovává existující značky a metadata; nicméně události a makra se spouštějí pouze v PowerPointu na Windows, pokud to bezpečnost umožňuje. Knihovna nespouští VBA.