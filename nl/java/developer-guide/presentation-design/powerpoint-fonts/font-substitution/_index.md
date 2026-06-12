---
title: Lettertypevervanging configureren in presentaties met Java
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/java/font-substitution/
keywords:
- lettertype
- lettertype vervangen
- lettertypesubstitutie
- lettertype vervangen
- lettertypevervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Schakel optimale lettertypesubstitutie in Aspose.Slides voor Java in bij het converteren van PowerPoint‑ en OpenDocument‑presentaties naar andere bestandsformaten."
---
## **Overzicht**

Lettertypevervanging maakt het mogelijk dat Aspose.Slides een ander lettertype gebruikt wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. U kunt controleren welke lettertypen zijn vervangen door de `getSubstitutions`‑methode van de `IFontsManager`‑interface te gebruiken.

Aspose.Slides maakt het ook mogelijk om regels voor lettertypevervanging te definiëren. U kunt bijvoorbeeld opgeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en die regels vervolgens toepassen via de lettertypebeheerder van de presentatie.

## **Lettertypevervangingsregels instellen**

Aspose.Slides laat u regels instellen voor lettertypen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet benaderbaar is) als volgt:

1. Laad de betreffende presentatie.  
2. Laad het lettertype dat vervangen moet worden.  
3. Laad het nieuwe lettertype.  
4. Voeg een regel toe voor de vervanging.  
5. Voeg de regel toe aan de collectie van lettertypevervangingsregels van de presentatie.  
6. Genereer de dia‑afbeelding om het effect te observeren.

Deze Java‑code toont het proces van lettertypevervanging:

```java
// Laadt een presentatie
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat zal worden vervangen
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Laadt het nieuwe lettertype
    IFontData destFont = new FontData("Arial");
    
    // Voegt een lettertype‑regel toe voor lettertypevervanging
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Voegt de regel toe aan de collectie van lettertypevervangingsregels
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Voegt een collectie van lettertype‑regels toe aan de regel‑lijst
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Lettertype Arial wordt gebruikt in plaats van SomeRareFont wanneer dat laatste ontoegankelijk is
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Slaat de afbeelding op schijf in JPEG‑formaat
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

U wilt misschien [**Lettertypevervanging**](/slides/nl/java/font-replacement/) bekijken. 

{{% /alert %}}

## **Beperkingen voor wiskundige formulelettertypen**

Regels voor lettertypevervanging nemen deel aan het standaard selectieproces van lettertypen dat tijdens het renderen en converteren wordt gebruikt. Ze zijn geschikt voor gewone tekstscenario’s waarin Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Voor wiskundige formules in Office bestaat echter een belangrijke beperking. Als een formule is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het oorspronkelijke **Cambria Math**‑lettertype nodig hebben om de lay‑out van de formule correct te berekenen en te renderen. Daarom wordt het vervangen van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van formules en kan er nog steeds een uitzondering optreden die aangeeft dat **Cambria Math** vereist is.

Zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime om dergelijke presentaties succesvol te converteren. U kunt het lettertype installeren in het besturingssysteem of het aanbieden als een [extern lettertype](/slides/nl/java/custom-font/) zodat het kan deelnemen aan het normale selectieproces van lettertypen tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van formules. De hierboven beschreven standaardregels voor lettertypevervanging blijven van toepassing op gewone presentatietekst wanneer het originele lettertype ontoegankelijk is.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertypesubstitutie?**

[Lettertypevervanging](/slides/nl/java/font-replacement/) is een geforceerde overschrijving van het ene lettertype door een ander in de gehele presentatie. Substitutie is een regel die wordt geactiveerd onder een specifieke voorwaarde, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is, waarna een aangewezen fallback‑lettertype wordt gebruikt.

**Wanneer worden substitutieregels precies toegepast?**

De regels nemen deel aan de standaard [lettertype‑selectie](/slides/nl/java/font-selection-sequence/) die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek probeert het dichtstbijzijnde beschikbare systeemlettertype te kiezen, vergelijkbaar met het gedrag van PowerPoint.

**Kan ik aangepaste externe lettertypen toevoegen tijdens runtime om substitutie te vermijden?**

Ja. U kunt [externe lettertypen](/slides/nl/java/custom-font/) toevoegen tijdens runtime zodat de bibliotheek ze meeneemt bij selectie en rendering, ook voor daaropvolgende conversies.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; u voegt lettertypen toe en gebruikt ze op eigen risico en verantwoordelijkheid.

**Zijn er verschillen in substitutiedrag op Windows, Linux en macOS?**

Ja. Het ontdekken van lettertypen start vanuit de lettertype‑mappen van het besturingssysteem. De set standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op de beschikbaarheid en de noodzaak van substitutie.

**Hoe bereid ik de omgeving voor om onverwachte substitutie tijdens batch‑conversies te minimaliseren?**

Synchroniseer de lettertype‑set tussen machines of containers, [voeg de benodigde externe lettertypen](/slides/nl/java/custom-font/) toe voor de uitvoer‑documenten, en [embed lettertypen](/slides/nl/java/embedded-font/) in presentaties waar mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.