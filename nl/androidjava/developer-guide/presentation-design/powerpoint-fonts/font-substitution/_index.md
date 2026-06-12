---
title: Lettertype‑substitutie configureren in presentaties op Android
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Schakel optimale lettertype‑substitutie in Aspose.Slides voor Android via Java in bij het converteren van PowerPoint‑ en OpenDocument‑presentaties naar andere bestandsformaten."
---
## **Overzicht**

Lettertype-substitutie stelt Aspose.Slides in staat om een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. Je kunt controleren welke lettertypen zijn vervangen door de methode `getSubstitutions` van de `IFontsManager` interface te gebruiken.

Aspose.Slides maakt het ook mogelijk om regels voor lettertype‑substitutie te definiëren. Je kunt bijvoorbeeld opgeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en die regels vervolgens toepassen via de lettertype‑manager van de presentatie.

## **Regels voor lettertype‑substitutie instellen**

Aspose.Slides stelt je in staat om regels voor lettertypen in te stellen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op de volgende manier:

1. Laad de betreffende presentatie.
2. Laad het lettertype dat vervangen moet worden.
3. Laad het nieuwe lettertype.
4. Voeg een regel toe voor de vervanging.
5. Voeg de regel toe aan de collectie van vervangingsregels voor lettertypen van de presentatie.
6. Genereer de dia‑afbeelding om het effect te observeren.

Deze Java‑code demonstreert het proces van lettertype‑substitutie:

```java
// Laadt een presentatie
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat wordt vervangen
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Laadt het nieuwe lettertype
    IFontData destFont = new FontData("Arial");
    
    // Voegt een lettertype‑regel toe voor lettertype‑vervanging
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Voegt de regel toe aan de collectie van vervangingsregels voor lettertypen
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Voegt een collectie van lettertype‑regels toe aan de regellijst
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Lettertype Arial wordt gebruikt in plaats van SomeRareFont wanneer het laatste ontoegankelijk is
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Slaat de afbeelding op schijf op in het JPEG‑formaat
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Je wilt misschien [**Vervanging van lettertype**](/slides/nl/androidjava/font-replacement/) zien.

{{% /alert %}}

## **Beperkingen voor wiskundige formule‑lettertypen**

Regels voor lettertype‑substitutie maken deel uit van het standaard selectieproces van lettertypen dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor gewone tekstopmaken waarbij Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Echter, Office‑wiskunde‑formules hebben een belangrijke beperking. Als een formule is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het originele **Cambria Math**‑lettertype nodig hebben om de lay‑out van de formule correct te berekenen en te renderen. Daarom wordt het vervangen van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van formules en kan er nog steeds een uitzondering optreden die aangeeft dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol te converteren, moet je ervoor zorgen dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. Je kunt het lettertype installeren in het besturingssysteem of het aanbieden als een [extern lettertype](/slides/nl/androidjava/custom-font/) zodat het kan deelnemen aan het normale selectieproces van lettertypen tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van formules. De bovenstaande standaardregels voor lettertype‑substitutie blijven van toepassing op gewone presentatietekst wanneer het oorspronkelijke lettertype ontoegankelijk is.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Vervanging](/slides/nl/androidjava/font-replacement/) is een geforceerde overschrijving van één lettertype door een ander in de hele presentatie. Substitutie is een regel die onder een specifieke voorwaarde wordt geactiveerd, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is, waarna een aangewezen reserve‑lettertype wordt gebruikt.

**Wanneer precies worden substitutieregels toegepast?**

De regels maken deel uit van de standaard [lettertype‑selectie](/slides/nl/androidjava/font-selection-sequence/) volgorde die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie geconfigureerd is en het lettertype ontbreekt op het systeem?**

De bibliotheek zal proberen het dichtstbijzijnde beschikbare systeembrede lettertype te kiezen, vergelijkbaar met hoe PowerPoint zich zou gedragen.

**Kan ik aangepaste externe lettertypen tijdens runtime toevoegen om substitutie te vermijden?**

Ja. Je kunt [externe lettertypen toevoegen](/slides/nl/androidjava/custom-font/) tijdens runtime zodat de bibliotheek ze in overweging neemt voor selectie en rendering, inclusief voor volgende conversies.

**Distribueert Aspose enige lettertypen met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; je voegt lettertypen toe en gebruikt ze op eigen risico en verantwoordelijkheid.

**Zijn er verschillen in substitutiegedrag op Windows, Linux en macOS?**

Ja. Het ontdekken van lettertypen begint bij de lettertype‑mappen van het besturingssysteem. De set van standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op de beschikbaarheid en de noodzaak van substitutie.

**Hoe moet ik de omgeving voorbereiden om onverwachte substitutie tijdens batch‑conversies te minimaliseren?**

Synchroniseer de set lettertypen over machines of containers, [voeg de externe lettertypen](/slides/nl/androidjava/custom-font/) toe die nodig zijn voor de uitvoerdocumenten, en [embed lettertypen](/slides/nl/androidjava/embedded-font/) in presentaties wanneer mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.