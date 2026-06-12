---
title: Lettertype‑vervanging configureren in presentaties in .NET
linktitle: Lettertype‑vervanging
type: docs
weight: 70
url: /nl/net/font-substitution/
keywords:
- lettertype
- lettertype vervangen
- lettertype‑substitutie
- lettertype vervangen
- lettertype‑vervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Schakel optimale lettertype‑substitutie in Aspose.Slides voor .NET in bij het converteren van PowerPoint‑ en OpenDocument‑presentaties naar andere bestandsformaten."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat om een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. U kunt controleren welke lettertypen zijn vervangen door de `GetSubstitutions`‑methode van de `IFontsManager`‑interface te gebruiken.

Aspose.Slides maakt het ook mogelijk om regels voor lettertypevervanging te definiëren. Bijvoorbeeld, u kunt opgeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en die regels vervolgens toepassen via de lettertype‑manager van de presentatie.

## **Lettertypevervangingen ophalen**

Om u in staat te stellen de lettertypen van de presentatie te achterhalen die tijdens het renderen van een presentatie worden vervangen, biedt Aspose.Slides de [GetSubstitution](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getsubstitutions/)‑methode van de [IFontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/) interface.

De C#‑code laat zien hoe u alle lettertypevervangingen kunt ophalen die worden uitgevoerd wanneer een presentatie wordt gerenderd:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Regels voor lettertypevervanging instellen**

Aspose.Slides stelt u in staat om regels voor lettertypen in te stellen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op de volgende manier:

1. Laad de relevante presentatie.
2. Laad het lettertype dat vervangen zal worden.
3. Laad het nieuwe lettertype.
4. Voeg een regel toe voor de vervanging.
5. Voeg de regel toe aan de collectie van lettertypevervangingsregels van de presentatie.
6. Genereer de dia‑afbeelding om het effect te observeren.

Deze C#‑code demonstreert het proces van lettertypevervanging:
```c#
// Laadt een presentatie
Presentation presentation = new Presentation("Fonts.pptx");

// Laadt het bronlettertype dat zal worden vervangen
IFontData sourceFont = new FontData("SomeRareFont");

// Laadt het nieuwe lettertype
IFontData destFont = new FontData("Arial");

// Voegt een lettertype‑regel toe voor vervanging
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Voegt de regel toe aan de collectie van vervangingsregels
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Voegt de collectie van lettertype‑regels toe aan de regel­lijst
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Slaat de afbeelding op schijf op in JPEG‑formaat
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
U wilt misschien [**Lettertypevervanging**](/slides/nl/net/font-replacement/) zien. 
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertypevervangingsregels nemen deel aan het standaard lettertype‑selectieproces dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor reguliere‑tekstscenario's waarin Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Echter, Office‑wiskundige vergelijkingen hebben een belangrijke beperking. Als een vergelijking is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het oorspronkelijke **Cambria Math**‑lettertype nodig hebben om de lay-out van de vergelijking correct te berekenen en weer te geven. Daarom wordt het vervangen van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van vergelijkingen en kan dit nog steeds resulteren in een uitzondering die aangeeft dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol te converteren, moet u ervoor zorgen dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. U kunt het lettertype installeren in het besturingssysteem of leveren als een [extern lettertype](/slides/nl/net/custom-font/) zodat het kan deelnemen aan het normale lettertype‑selectieproces tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van vergelijkingen. De standaard lettertypevervangingsregels die hierboven zijn beschreven blijven van toepassing op reguliere presentatietekst wanneer het oorspronkelijke lettertype ontoegankelijk is.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertype‑substitutie?**

[Vervanging](/slides/nl/net/font-replacement/) is een geforceerde overschrijving van één lettertype door een ander in de hele presentatie. Substitutie is een regel die wordt geactiveerd onder een specifieke voorwaarde, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is, waarna een aangewezen alternatief lettertype wordt gebruikt.

**Wanneer precies worden substitatieregels toegepast?**

De regels nemen deel aan de standaard [lettertype‑selectie](/slides/nl/net/font-selection-sequence/)‑reeks die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek zal proberen het dichtstbijzijnde beschikbare systeembrede lettertype te kiezen, vergelijkbaar met hoe PowerPoint zich zou gedragen.

**Kan ik aangepaste externe lettertypen tijdens runtime koppelen om substitutie te vermijden?**

Ja. U kunt tijdens runtime [externe lettertypen](/slides/nl/net/custom-font/) toevoegen zodat de bibliotheek ze in overweging neemt voor selectie en weergave, inclusief voor latere conversies.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; u voegt lettertypen toe en gebruikt ze op eigen risico en verantwoordelijkheid.

**Zijn er verschillen in het gedrag van substitutie op Windows, Linux en macOS?**

Ja. Het zoeken naar lettertypen start in de lettertype‑mappen van het besturingssysteem. De verzameling standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat de beschikbaarheid en de noodzaak voor substitutie beïnvloedt.

**Hoe moet ik de omgeving voorbereiden om onverwachte substitutie tijdens batchconversies te minimaliseren?**

Synchroniseer de set lettertypen over machines of containers, [voeg de externe lettertypen](/slides/nl/net/custom-font/) toe die nodig zijn voor de outputdocumenten, en [embed lettertypen](/slides/nl/net/embedded-font/) in presentaties wanneer mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.