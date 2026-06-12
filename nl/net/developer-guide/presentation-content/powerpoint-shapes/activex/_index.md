---
title: Beheer ActiveX-besturingselementen in Presentaties in .NET
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
- mediaspeler
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe Aspose.Slides for .NET ActiveX benut om PowerPoint-presentaties te automatiseren en te verbeteren, waardoor ontwikkelaars krachtige controle over dia's krijgen."
---
## **Inleiding**

ActiveX-besturingselementen worden gebruikt in presentaties. Aspose.Slides for .NET stelt u in staat ActiveX-besturingselementen te beheren, maar het beheren ervan is iets lastiger en anders dan normale presentatievormen. Vanaf Aspose.Slides for .NET 6.9.0 ondersteunt de component het beheren van ActiveX-besturingselementen. Op dit moment kunt u een reeds toegevoegde ActiveX-besturingselement in uw presentatie benaderen en wijzigen of verwijderen met behulp van de verschillende eigenschappen. Onthoud dat ActiveX-besturingselementen geen vormen zijn en geen deel uitmaken van de IShapeCollection van de presentatie, maar van de aparte IControlCollection. Dit artikel laat zien hoe u ermee werkt.

## **ActiveX-besturingselementen wijzigen**
1. Maak een instantie van de Presentation‑klasse en laad de presentatie die ActiveX-besturingselementen bevat.  
2. Verkrijg een referentie naar een dia op basis van de index.  
3. Benader de ActiveX-besturingselementen in de dia via de IControlCollection.  
4. Benader het ActiveX‑besturingselement TextBox1 met behulp van het ControlEx‑object.  
5. Wijzig de verschillende eigenschappen van het TextBox1 ActiveX‑besturingselement, waaronder tekst, lettertype, lettergrootte en frame‑positie.  
6. Benader het tweede besturingselement met de naam CommandButton1.  
7. Wijzig de knopbijschrift, het lettertype en de positie.  
8. Verplaats de positie van de frames van de ActiveX‑besturingselementen.  
9. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```c#
// Toegang tot de presentatie met ActiveX-besturingselementen
Presentation presentation = new Presentation("ActiveX.pptm");

// Toegang tot de eerste dia in de presentatie
ISlide slide = presentation.Slides[0];

// tekst van TextBox wijzigen
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // vervangende afbeelding wijzigen. PowerPoint zal deze afbeelding vervangen tijdens ActiveX-activatie, dus soms is het OK om de afbeelding onveranderd te laten.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// bijschrift van knop wijzigen
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // vervangende afbeelding wijzigen
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ActiveX-frames 100 punten omlaag verplaatsen
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Presentatie opslaan met bewerkte ActiveX-besturingselementen
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Nu besturingselementen verwijderen
slide.Controls.Clear();

// Presentatie opslaan met verwijderde ActiveX-besturingselementen
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Een ActiveX Media Player‑besturingselement toevoegen**
1. Maak een instantie van de Presentation‑klasse en laad de voorbeeldpresentatie die Media Player ActiveX‑besturingselementen bevat.  
2. Maak een instantie van de doelformaat Presentation‑klasse en genereer een lege presentatiestructuur.  
3. Kloon de dia met het Media Player ActiveX‑besturingselement uit de sjabloonpresentatie naar de doel‑Presentation.  
4. Benader de gekloonde dia in de doel‑Presentation.  
5. Benader de ActiveX‑besturingselementen in de dia via de IControlCollection.  
6. Benader het Media Player ActiveX‑besturingselement en stel het videopad in via de eigenschappen.  
7. Sla de presentatie op als een PPTX‑bestand.

```c#
// Instantie van de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation presentation = new Presentation("template.pptx");

// Maak een lege presentatie‑instantie
Presentation newPresentation = new Presentation();

// Verwijder de standaarddia
newPresentation.Slides.RemoveAt(0);

// Kloon de dia met Media Player ActiveX‑besturingselement
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Toegang tot het Media Player ActiveX‑besturingselement en stel het videopad in
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Sla de presentatie op
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Behoudt Aspose.Slides ActiveX‑besturingselementen bij het lezen en opnieuw opslaan als ze niet kunnen worden uitgevoerd in de .NET‑runtime?**

Ja. Aspose.Slides beschouwt ze als onderdeel van de presentatie en kan hun eigenschappen en frames lezen/wijzigen; het uitvoeren van de besturingselementen zelf is niet vereist om ze te behouden.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten in een presentatie?**

ActiveX‑besturingselementen zijn interactieve beheerde besturingselementen (knoppen, tekstvakken, mediaplayer), terwijl [OLE](/slides/nl/net/manage-ole/) verwijst naar ingebedde applicatie‑objecten (bijvoorbeeld een Excel‑werkblad). Ze worden anders opgeslagen en behandeld en hebben verschillende eigenschapsmodellen.

**Werken ActiveX‑events en VBA‑macro’s als het bestand is aangepast door Aspose.Slides?**

Aspose.Slides behoudt de bestaande markup en metadata; echter, events en macro‑s worden alleen uitgevoerd binnen PowerPoint op Windows wanneer de beveiligingsinstellingen dit toestaan. De bibliotheek voert geen VBA uit.