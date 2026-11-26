---
title: Hantera ActiveX‑kontroller i presentationer i .NET
linktitle: ActiveX
type: docs
weight: 80
url: /sv/net/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- mediaspelare
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Redigera ActiveX‑textrutor och -knappar, uppdatera kontroll‑förhandsvisningar och återanvänd en Windows Media Player‑kontroll i PowerPoint‑presentationer med Aspose.Slides för .NET."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element såsom textrutor, kommandoknappar och mediespelare. Aspose.Slides för .NET exponerar en bilds kontroller via [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att undersöka en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), och varje nyckel‑värde‑par i [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Det läser presentationen utan att aktivera kontroller, anropa händelser eller makron, ändra värden eller spara filen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Urvalet från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapskollektion visas som `[]`. För kontroller som använder binär lagring kan `Properties` returnera `null`, visas som `Properties unavailable`. Om du bara behöver namnen, använd [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) efter null‑kontrollen. Rapporten listar de egenskaper som är tillgängliga i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Modifiera ActiveX‑kontroller**

Exemplet förutsätter en makroaktiverad presentation med en textruta namngiven `TextBox1` och en kommandoknapp namngiven `CommandButton1` på den första bilden. Det använder [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsvisning som PowerPoint kan visa innan aktivering. Tillhandahåll en PNG för varje kontroll som visar den uppdaterade texten och utseendet. Exemplet tilldelar dessa bilder via [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att ändra dess [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Det sparar den redigerade presentationen i PPTM‑format, och använder sedan [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) för att spara en annan kopia med alla ActiveX‑kontroller borttagna från den bilden.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall där den första bilden innehåller en spelare namngiven `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) och sparar den klonade bilden som den enda bilden i resultatet. Videon förblir extern, så välj en sökväg som spelaren kan nå under uppspelning.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE-objekt](/slides/sv/net/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, såsom ett Excel‑kalkylblad.

**Kommer ActiveX‑händelser fortfarande att utlösa VBA‑makron efter att jag sparar en presentation med Aspose.Slides?**

Spara presentationen i ett makroaktiverat format som PPTM för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.