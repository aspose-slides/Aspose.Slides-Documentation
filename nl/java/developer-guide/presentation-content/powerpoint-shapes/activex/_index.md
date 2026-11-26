---
title: Beheer ActiveX-controls in presentaties in Java
linktitle: ActiveX
type: docs
weight: 80
url: /nl/java/activex/
keywords:
- ActiveX
- ActiveX-control
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Bewerk ActiveX-tekstvakken en -knoppen, werk de voorbeeldweergaven van controls bij, en hergebruik een Windows Media Player-control in PowerPoint-presentaties met Aspose.Slides voor Java."
---
## **Inleiding**

ActiveX-controls geven een PowerPoint-dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaplayers. Aspose.Slides for Java maakt de controls van een dia toegankelijk via [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Gebruik deze collectie om een control te bewerken, te verplaatsen op de dia, of te verwijderen.

## **Lijst van ActiveX-controls en hun opgeslagen eigenschappen**

Om een onbekende template te inspecteren, open je deze voor lezen en itereren door de controls op elke dia. Het voorbeeld rapporteert het diapnummer, de controlnaam, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), en elk sleutel-waarde-paar in [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Het leest de presentatie zonder de controls te activeren, gebeurtenissen of macro's aan te roepen, waarden te wijzigen, of het bestand op te slaan.

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

Geselecteerde output van `ActiveX.pptm` toont een tekstvak en een opdrachtknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapencollectie verschijnt als `[]`. Voor controls die binaire opslag gebruiken, kan [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) `null` retourneren, weergegeven als `Properties unavailable`. Als je alleen de namen nodig hebt, gebruik dan [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) na de null-check. Het rapport geeft de beschikbare eigenschappen weer uit de presentatie. Een control kan tijdens runtime extra eigenschappen ondersteunen.

## **ActiveX-controls wijzigen**

Het voorbeeld verwacht een macro-ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een opdrachtknop genaamd `CommandButton1` op de eerste dia. Het gebruikt de [collectie van control‑eigenschappen](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) om de waarde van het tekstvak en de bijschrift van de knop te wijzigen. Elke control heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activatie. Lever een PNG voor elke control die de bijgewerkte tekst en weergave toont. Het voorbeeld kent deze afbeeldingen toe via [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Het voorbeeld verplaatst elke control op de eerste dia 100 punten naar beneden door het frame in te stellen met [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Het slaat de bewerkte presentatie op in PPTM‑formaat, en gebruikt vervolgens [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) om een tweede kopie op te slaan waarbij alle ActiveX-controls van die dia zijn verwijderd.

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

## **ActiveX‑mediaplayer‑control toevoegen**

Om een geconfigureerde Windows Media Player‑control opnieuw te gebruiken, begin met een template waarvan de eerste dia een speler bevat genaamd `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in in zijn [eigenschappen‑collectie](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de output. De video blijft extern, kies daarom een pad dat de speler tijdens het afspelen kan bereiken.

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

## **Veelgestelde vragen**

**Kan Aspose.Slides ActiveX-controls behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan controls lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX-controls van OLE‑objecten?**

ActiveX-controls laten gebruikers met een dia interageren, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE‑object](/slides/nl/java/manage-ole/) laat een dia inhoud bevatten of koppelen die wordt beheerd door een andere applicatie, zoals een Excel-werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro’s activeren nadat ik een presentatie met Aspose.Slides heb opgeslagen?**

Sla de presentatie op in een macro-ingeschakeld formaat zoals PPTM om het VBA-project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenishandlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX-controls als macro’s toestaan.