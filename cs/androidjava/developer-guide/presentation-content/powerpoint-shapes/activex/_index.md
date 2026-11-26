---
title: Správa ActiveX ovládacích prvků v prezentacích na Androidu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/androidjava/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro Android prostřednictvím Javy."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní prvky, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides pro Android prostřednictvím Javy zpřístupňuje ovládací prvky snímku pomocí [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunu po snímku nebo odebrání. V níže uvedených příkladech používejte cesty k souborům, které může vaše Android aplikace číst, a vyberte zapisovatelnou lokaci pro každou výstupní prezentaci.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a projděte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), a každý pár klíč‑hodnota v [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Prezentaci načítá bez aktivace ovládacích prvků, spouštění událostí nebo maker, změny hodnot nebo ukládání souboru.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Vybraný výstup ze souboru `ActiveX.pptm` ukazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazuje jako `[]`. Pro ovládací prvky, které používají binární úložiště, může [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) vrátit `null`, což je zobrazeno jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) po kontrole na `null`. Zpráva uvádí vlastnosti dostupné v prezentaci. Ovládací prvek může během běhu podporovat další vlastnosti.

## **Úprava ActiveX ovládacích prvků**

Příklad očekává prezentaci s povolenými makry, která má na prvním snímku textové pole pojmenované `TextBox1` a tlačítko příkazu pojmenované `CommandButton1`. Používá [kolekci vlastností ovládacího prvku](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) ke změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek zobrazující jeho aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Příklad přesune každý ovládací prvek na prvním snímku dolů o 100 bodů nastavením jeho rámce pomocí [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Uloží upravenou prezentaci ve formátu PPTM a poté použije [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) k uložení druhé kopie se všemi ActiveX ovládacími prvky odstraněnými z tohoto snímku.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Přidání ActiveX ovládacího prvku Media Player**

Pro opětovné použití nakonfigurovaného ovládacího prvku Windows Media Player začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [kolekci vlastností](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) a uloží klonovaný snímek jako jediný snímek ve výstupu. Video zůstává externí, takže zvolte cestu, ke které může přehrávač během přehrávání přistupovat.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **Často kladené otázky**

**Může Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides dokáže číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, bez jejich aktivace.

**Jak se ActiveX ovládací prvky liší od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadáním textu nebo kliknutím na tlačítko. [objekt OLE](/slides/cs/androidjava/manage-ole/) umožňuje, aby snímek obsahoval nebo odkazoval na obsah spravovaný jinou aplikací, například sešitem Excel.

**Budou události ActiveX i po uložení prezentace s Aspose.Slides spouštět VBA makra?**

Uložte prezentaci ve formátu s povolenými makry, například PPTM, aby byl zachován její projekt VBA. PowerPoint pro Windows může spouštět existující obslužné rutiny událostí, pokud jeho bezpečnostní nastavení umožňují jak ActiveX ovládací prvky, tak makra.