---
title: Správa ActiveX ovládacích prvků v prezentacích v jazyce Java
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
- mediální přehrávač
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro Java."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní prvky jako textová pole, tlačítka příkazů a mediální přehrávače. Aspose.Slides for Java zpřístupňuje ovládací prvky snímku prostřednictvím [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunu na snímku nebo odebrání.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a iterujte přes ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), a každý pár klíč‑hodnota v [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Načte prezentaci, aniž by aktivoval ovládací prvky, spouštěl události nebo makra, měnil hodnoty nebo ukládal soubor.

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

Prázdná kolekce vlastností se zobrazuje jako `[]`. Pro ovládací prvky používající binární úložiště může [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) vrátit `null`, zobrazené jako `Properties unavailable`. Pokud potřebujete jen názvy, použijte [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) po kontrole na null. Zpráva uvádí vlastnosti dostupné z prezentace. Ovládací prvek může během běhu podporovat další vlastnosti.

## **Úprava ActiveX ovládacích prvků**

Příklad očekává prezentaci povolenou pro makra s textovým polem pojmenovaným `TextBox1` a tlačítkem příkazu pojmenovaným `CommandButton1` na prvním snímku. Používá [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) k změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek zobrazující aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Příklad přesune každý ovládací prvek na prvním snímku dolů o 100 bodů nastavením jeho rámce pomocí [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Uloží upravenou prezentaci ve formátu PPTM a poté použije [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) k uložení druhé kopie se všemi ActiveX ovládacími prvky odstraněnými z tohoto snímku.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
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

Pro opakované použití nakonfigurovaného ovládacího prvku Windows Media Player začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) a uloží zkopírovaný snímek jako jediný snímek ve výstupu. Video zůstává externí, proto zvolte cestu, kterou může přehrávač během přehrávání přistupovat.

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

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se ActiveX ovládací prvky liší od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, např. zadáním textu nebo kliknutím na tlačítko. [OLE objekt](/slides/cs/java/manage-ole/) umožňuje, aby snímek obsahoval nebo odkazoval na obsah spravovaný jinou aplikací, jako je list Excelu.

**Spustí se po uložení prezentace s Aspose.Slides VBA makra pomocí ActiveX událostí?**

Uložte prezentaci do formátu povoleného pro makra, např. PPTM, aby byl zachován její projekt VBA. PowerPoint pro Windows může spouštět stávající obslužné rutiny událostí, pokud jeho bezpečnostní nastavení dovolí jak ActiveX ovládací prvky, tak makra.