---
title: Hantera ActiveX-kontroller i presentationer på Android
linktitle: ActiveX
type: docs
weight: 80
url: /sv/androidjava/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- hantera ActiveX
- lägga till ActiveX
- ändra ActiveX
- mediaspelare
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Redigera ActiveX-textrutor och -knappar, uppdatera kontrollernas förhandsgranskningar och återanvänd en Windows Media Player-kontroll i PowerPoint-presentationer med Aspose.Slides för Android via Java."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element såsom textrutor, kommandoknappar och mediaplayer. Aspose.Slides for Android via Java exponerar en bilds kontroller via [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den. I exemplen nedan, använd filsökvägar som din Android‑app kan läsa och välj en skrivbar plats för varje utskriven presentation.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att inspektera en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), och varje nyckel‑värde‑par i [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Det läser presentationen utan att aktivera kontroller, utlösa händelser eller makron, ändra värden eller spara filen.

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

Det valda resultatet från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapssamling visas som `[]`. För kontroller som använder binär lagring kan [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) returnera `null`, vilket visas som `Properties unavailable`. Om du bara behöver namnen, använd [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) efter null‑kontrollen. Rapporten listar de egenskaper som finns i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Ändra ActiveX‑kontroller**

Exemplet förutsätter en makronaktiverad presentation med en textruta namngiven `TextBox1` och en kommandoknapp namngiven `CommandButton1` på den första bilden. Det använder [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsgranskning som PowerPoint kan visa innan aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att sätta dess ram med [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Det sparar den redigerade presentationen i PPTM‑format, och använder sedan [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) för att spara en andra kopia där alla ActiveX‑kontroller har tagits bort från den bilden.

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

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall där den första bilden innehåller en spelare namngiven `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) och sparar den klonade bilden som den enda bilden i resultatet. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

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

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE‑objekt](/slides/sv/androidjava/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, såsom ett Excel‑arbetsblad.

**Kommer ActiveX‑händelser fortfarande att utlösa VBA‑makron efter att jag sparat en presentation med Aspose.Slides?**

Spara presentationen i ett makronaktiverat format, såsom PPTM, för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.