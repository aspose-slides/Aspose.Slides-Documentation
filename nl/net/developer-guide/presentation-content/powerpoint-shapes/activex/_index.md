---
title: Beheer ActiveX‑besturingselementen in presentaties in .NET
linktitle: ActiveX
type: docs
weight: 80
url: /nl/net/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaplayer
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bewerk ActiveX‑tekstvakken en -knoppen, werk besturingselement‑voorbeelden bij en hergebruik een Windows Media Player‑besturingselement in PowerPoint‑presentaties met Aspose.Slides voor .NET."
---
## **Introductie**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, opdrachtknoppen en mediaplayers. Aspose.Slides voor .NET maakt de besturingselementen van een dia beschikbaar via [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Gebruik deze collectie om een besturingselement te bewerken, het op de dia te verplaatsen of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende template te inspecteren, opent u deze voor lezen en doorloopt u de besturingselementen op elke dia. Het voorbeeld meldt het dianummer, de naam van het besturingselement, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) en elk sleutel‑waarde‑paar in [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Het leest de presentatie zonder besturingselementen te activeren, events of macro's uit te voeren, waarden te wijzigen of het bestand op te slaan.

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

Geselecteerde uitvoer uit `ActiveX.pptm` toont een tekstvak en een opdrachtknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapscollectie wordt weergegeven als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan `Properties` `null` retourneren, weergegeven als `Properties unavailable`. Als u alleen de namen nodig hebt, gebruikt u [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) na de null‑controle. Het rapport geeft de eigenschappen weer die beschikbaar zijn vanuit de presentatie. Een besturingselement kan tijdens runtime extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld verwacht een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een opdrachtknop genaamd `CommandButton1` op de eerste dia. Het gebruikt de [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) om de waarde van het tekstvak en de bijschrift van de knop te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activering. Lever een PNG voor elk besturingselement die de bijgewerkte tekst en uitstraling toont. Het voorbeeld kent deze afbeeldingen toe via [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door zijn [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) te wijzigen. Het slaat de bewerkte presentatie op in PPTM‑formaat en gebruikt vervolgens [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia zijn verwijderd.

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

## **ActiveX‑mediaplayer‑besturingselement toevoegen**

Om een geconfigureerd Windows Media Player‑besturingselement opnieuw te gebruiken, start u met een template waarvan de eerste dia een speler bevat met de naam `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in de [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) in en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler tijdens het afspelen kan bereiken.

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

## **FAQ**

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers interageren met een dia, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE object](/slides/nl/net/manage-ole/) laat een dia inhoud bevatten of koppelen naar inhoud die wordt beheerd door een andere toepassing, zoals een Excel‑werkblad.

**Zullen ActiveX‑events nog VBA‑macro's activeren nadat ik een presentatie met Aspose.Slides heb opgeslagen?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande event‑handlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro's toestaan.