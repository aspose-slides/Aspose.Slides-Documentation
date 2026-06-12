---
title: Lettertypevervanging configureren in presentaties met JavaScript
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/nodejs-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Schakel optimale lettertypevervanging in Aspose.Slides voor Node.js in bij het converteren van PowerPoint- en OpenDocument-presentaties naar andere bestandsformaten in JavaScript."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. U kunt controleren welke lettertypen zijn vervangen door de `getSubstitutions`‑methode van de `FontsManager`‑klasse te gebruiken.

Aspose.Slides maakt ook het definiëren van regels voor lettertypevervanging mogelijk. U kunt bijvoorbeeld aangeven dat een ontoegankelijk lettertype vervangen moet worden door een ander beschikbaar lettertype en deze regels vervolgens toepassen via de lettertype‑manager van de presentatie.

## **Stel regels voor lettertypevervanging in**

Aspose.Slides stelt u in staat regels voor lettertypen in te stellen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op de volgende manier:

1. Laad de betreffende presentatie.  
2. Laad het lettertype dat vervangen zal worden.  
3. Laad het nieuwe lettertype.  
4. Voeg een regel toe voor de vervanging.  
5. Voeg de regel toe aan de collectie van lettertypevervangingsregels van de presentatie.  
6. Genereer de dia‑afbeelding om het effect te observeren.

Deze JavaScript‑code demonstreert het proces van lettertypevervanging:

```javascript
// Laadt een presentatie
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat vervangen zal worden
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Laadt het nieuwe lettertype
    var destFont = new aspose.slides.FontData("Arial");
    // Voegt een lettertype‑regel toe voor vervanging
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Voegt de regel toe aan de collectie van lettertype‑vervangingsregels
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Voegt een collectie van lettertype‑regels toe aan de regelslijst
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Lettertype Arial wordt gebruikt in plaats van SomeRareFont wanneer dat laatste ontoegankelijk is
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Slaat de afbeelding op schijf op in JPEG‑formaat
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
U wilt misschien [**Lettertypevervanging**](/slides/nl/nodejs-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijkingslettertypen**

Lettertypevervangingsregels nemen deel aan het standaard lettertype‑selectieproces dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor reguliere tekstscenario’s waarin Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Er is echter een belangrijke beperking voor Office‑wiskundige vergelijkingen. Als een vergelijking is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het oorspronkelijke **Cambria Math**‑lettertype nodig hebben om de lay-out van de vergelijking correct te berekenen en weer te geven. Daarom wordt het vervangen van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van vergelijkingen en kan dit nog steeds leiden tot een uitzondering waarin wordt aangegeven dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol te converteren, moet u ervoor zorgen dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. U kunt het lettertype in het besturingssysteem installeren of het beschikbaar stellen als een [extern lettertype](/slides/nl/nodejs-java/custom-font/) zodat het kan deelnemen aan het normale lettertype‑selectieproces tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van vergelijkingen. De hierboven beschreven standaardregels voor lettertypevervanging blijven van toepassing op gewone presentatietekst wanneer het oorspronkelijke lettertype ontoegankelijk is.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertype‑substitutie?**

[Vervanging](/slides/nl/nodejs-java/font-replacement/) is een geforceerde overschrijving van één lettertype door een ander in de hele presentatie. Substitutie is een regel die geactiveerd wordt onder een specifieke voorwaarde, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is, waarna een aangewezen fallback‑lettertype wordt gebruikt.

**Wanneer precies worden substitutieregels toegepast?**

De regels nemen deel aan het standaard [lettertype‑selectie](/slides/nl/nodejs-java/font-selection-sequence/)‑proces dat wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek zal proberen het dichtstbijzijnde beschikbare systeemlettertype te kiezen, vergelijkbaar met hoe PowerPoint zich zou gedragen.

**Kan ik aangepaste externe lettertypen tijdens runtime toevoegen om substitutie te voorkomen?**

Ja. U kunt tijdens runtime [externe lettertypen toevoegen](/slides/nl/nodejs-java/custom-font/) zodat de bibliotheek ze in overweging neemt bij selectie en rendering, ook voor opvolgende conversies.

**Distribueert Aspose lettertypen mee met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; u voegt lettertypen toe en gebruikt ze naar eigen inzicht en verantwoordelijkheid.

**Zijn er verschillen in substitutiegedrag op Windows, Linux en macOS?**

Ja. Het vinden van lettertypen begint bij de lettertype‑mappen van het besturingssysteem. De set standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op beschikbaarheid en de noodzaak van substitutie.

**Hoe moet ik de omgeving voorbereiden om onvoorziene substitutie tijdens batch‑conversies te minimaliseren?**

Synchroniseer de lettertype‑set over machines of containers, [voeg de externe lettertypen](/slides/nl/nodejs-java/custom-font/) toe die nodig zijn voor de output‑documenten, en [embed lettertypen](/slides/nl/nodejs-java/embedded-font/) in presentaties waar mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.