---
title: Beheer ActiveX‑besturingselementen in presentaties op Android
linktitle: ActiveX
type: docs
weight: 80
url: /nl/androidjava/activex/
keywords:
- ActiveX
- ActiveX‑besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Bewerk ActiveX‑tekstvakken en -knoppen, werk besturingselement‑voorbeelden bij en hergebruik een Windows Media Player‑besturingselement in PowerPoint‑presentaties met Aspose.Slides voor Android via Java."
---
## **Inleiding**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaplayers. Aspose.Slides for Android via Java biedt de besturingselementen van een dia via [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Gebruik deze collectie om een besturingselement te bewerken, te verplaatsen op de dia, of te verwijderen. In de voorbeelden hieronder gebruikt u bestandspaden die uw Android‑app kan lezen en kiest u een beschrijfbare locatie voor elke uitvoerpresentatie.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende sjabloon te inspecteren, opent u deze om te lezen en doorloopt u de besturingselementen op elke dia. Het voorbeeld geeft het slidernummer, de naam van het besturingselement, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), en elk sleutel‑waarde‑paar in [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) weer. Het leest de presentatie zonder besturingselementen te activeren, gebeurtenissen of macro’s uit te voeren, waarden te wijzigen, of het bestand op te slaan.

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

Geselecteerde uitvoer van `ActiveX.pptm` toont een tekstvak en een opdrachtknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapscollectie verschijnt als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) `null` retourneren, weergegeven als `Properties unavailable`. Als u alleen de namen nodig heeft, gebruikt u [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) na de null‑controle. Het rapport lijst de eigenschappen op die beschikbaar zijn in de presentatie. Een besturingselement kan extra eigenschappen ondersteunen tijdens runtime.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld gaat uit van een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een opdrachtknop genaamd `CommandButton1` op de eerste dia. Het gebruikt de [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) om de waarde van het tekstvak en de bijschrift van de knop te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activering. Lever een PNG voor elk besturingselement dat de bijgewerkte tekst en uitstraling toont. Het voorbeeld kent deze afbeeldingen toe via [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Het voorbeeld verplaatst elk besturingselement op de eerste dia omlaag met 100 points door het frame in te stellen met [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Het slaat de bewerkte presentatie op in PPTM‑formaat, en gebruikt vervolgens [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia verwijderd zijn.

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

## **ActiveX‑mediaplayer‑besturingselement toevoegen**

Om een geconfigureerd Windows Media Player‑besturingselement opnieuw te gebruiken, start u met een sjabloon waarvan de eerste dia een speler bevat genaamd `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in via de [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler kan bereiken tijdens het afspelen.

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

## **FAQ**

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers interactie hebben met een dia, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE‑object](/slides/nl/androidjava/manage-ole/) laat een dia inhoud bevatten of ernaar linken die door een andere applicatie wordt beheerd, zoals een Excel‑werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro’s activeren nadat ik een presentatie opsla met Aspose.Slides?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenishandlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro’s toestaan.