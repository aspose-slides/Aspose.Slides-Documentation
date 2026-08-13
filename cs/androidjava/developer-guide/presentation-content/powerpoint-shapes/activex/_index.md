---
title: Správa ActiveX ovládacích prvků v prezentacích na Androidu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/androidjava/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- spravovat ActiveX
- přidat ActiveX
- upravit ActiveX
- mediální přehrávač
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Získejte návod, jak Aspose.Slides for Android via Java využívá ActiveX k automatizaci a vylepšení PowerPoint prezentací, poskytující vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides for Android via Java vám umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jsou o něco obtížnější na správu ve srovnání s běžnými tvary v prezentaci. Implementovali jsme podporu pro přidání aktivního ovládacího prvku Media Player v Aspose.Slides. Všimněte si, že ActiveX ovládací prvky nejsou tvary; nejsou součástí [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/). Jsou součástí samostatného [IControlCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrolcollection/) místo toho. V tomto tématu vám ukážeme, jak s nimi pracovat.

## **Přidání aktivního ovládacího prvku Media Player do snímku**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a vytvořte prázdnou prezentaci.
2. Získejte cílový snímek v [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
3. Přidejte aktivní ovládací prvek Media Player pomocí metody [addControl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) vystavené rozhraním [IControlCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrolcollection/).
4. Získejte aktivní ovládací prvek Media Player a nastavte cestu k videu pomocí jeho vlastností.
5. Uložte prezentaci jako soubor PPTX.

Tento ukázkový kód, založený na výše uvedených krocích, ukazuje, jak přidat aktivní ovládací prvek Media Player do snímku:

```java
import com.aspose.slides.*;

// Vytvořte prázdnou instanci prezentace
Presentation pres = new Presentation();
try {
    // Přidání aktivního ovládacího prvku Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Získání aktivního ovládacího prvku Media Player a nastavení cesty k videu
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Uložení prezentace
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Upravit ActiveX ovládací prvek**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 7.1.0 a novější verze jsou vybaveny komponentami pro správu ActiveX ovládacích prvků. Můžete získat již přidaný ActiveX ovládací prvek ve své prezentaci a upravit jej nebo smazat prostřednictvím jeho vlastností.

{{% /alert %}} 

Pro správu jednoduchého ActiveX ovládacího prvku, jako je textové pole a jednoduché tlačítko příkazu na snímku, postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přistupte k ActiveX ovládacím prvkům na snímku pomocí rozhraní [IControlCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrolcollection/).
4. Získejte ActiveX ovládací prvek TextBox1 pomocí objektu [IControl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrol/).
5. Změňte vlastnosti ActiveX ovládacího prvku TextBox1, které zahrnují text, písmo, výšku písma a pozici rámce.
6. Získejte druhý ovládací prvek nazvaný CommandButton1.
7. Změňte popisek tlačítka, písmo a pozici.
8. Posuňte polohu rámců ActiveX ovládacích prvků.
9. Uložte upravenou prezentaci do souboru PPTX.

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

    // změna textu TextBoxu
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Změna náhradního obrázku. PowerPoint nahradí tento obrázek během aktivace ActiveX,
        // takže je občas v pořádku nechat obrázek beze změny.
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

    // odstranění ovládacích prvků
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

### Uchovává Aspose.Slides ActiveX ovládací prvky při načítání a opětovném uložení, pokud nelze spustit v Java runtime?
Ano. Aspose.Slides je považuje za součást prezentace a umí číst/upravovat jejich vlastnosti a rámce; není nutné spouštět samotné ovládací prvky k jejich zachování.

### Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?
ActiveX ovládací prvky jsou interaktivní řízené prvky (tlačítka, textová pole, mediální přehrávač), zatímco [OLE](/slides/cs/androidjava/manage-ole/) označuje vložené aplikační objekty (například list Excel). Jsou ukládány a zpracovávány odlišně a mají jiný model vlastností.

### Fungují události ActiveX a makra VBA, pokud byl soubor upraven pomocí Aspose.Slides?
Aspose.Slides zachovává stávající značky a metadata; však události a makra se spouštějí pouze v PowerPointu ve Windows, pokud to bezpečnostní nastavení povolí. Knihovna nespouští VBA.