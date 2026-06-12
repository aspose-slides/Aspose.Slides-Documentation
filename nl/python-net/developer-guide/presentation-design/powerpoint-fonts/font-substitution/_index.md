---
title: Lettertypevervanging configureren in presentaties met Python
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/python-net/font-substitution/
keywords:
- lettertype
- lettertype substitueren
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Schakel optimale lettertypevervanging in Aspose.Slides voor Python via .NET in bij het converteren van PowerPoint & OpenDocument presentaties naar andere bestandsformaten."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat om een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. U kunt controleren welke lettertypen zijn vervangen door de `get_substitutions`-methode van de `FontsManager`-klasse te gebruiken.

Aspose.Slides maakt het ook mogelijk om regels voor lettertypevervanging te definiëren. Bijvoorbeeld, u kunt aangeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en vervolgens die regels toepassen via de lettertype‑manager van de presentatie.

## **Vervangingsregels instellen**

Aspose.Slides stelt u in staat om regels voor lettertypen in te stellen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op deze manier:

1. Laad de relevante presentatie.  
2. Laad het lettertype dat vervangen zal worden.  
3. Laad het nieuwe lettertype.  
4. Voeg een regel toe voor de vervanging.  
5. Voeg de regel toe aan de collectie van presentatie‑lettertypevervangingsregels.  
6. Genereer de dia‑afbeelding om het effect te observeren.

Deze Python‑code demonstreert het proces van lettertypevervanging:

```python
import aspose.slides as slides

# Laadt een presentatie
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Laadt het bronlettertype dat wordt vervangen
    sourceFont = slides.FontData("SomeRareFont")

    # Laadt het nieuwe lettertype
    destFont = slides.FontData("Arial")

    # Voegt een lettertype‑regel toe voor vervanging
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Voegt de regel toe aan de collectie van substitutieregels
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Voegt de collectie van lettertype‑regels toe aan de regelijst
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial lettertype wordt gebruikt in plaats van SomeRareFont wanneer het laatstgenoemde ontoegankelijk is
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Slaat de afbeelding op schijf in JPEG‑formaat
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 
U wilt misschien [**Lettertypevervanging**](/slides/nl/python-net/font-replacement/) bekijken. 
{{% /alert %}}

## **Beperkingen voor wiskundige‑equatie‑lettertypen**

Regels voor lettertypevervanging nemen deel aan het standaardlettertype‑selectieproces dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor normale tekstscenario's waarin Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Echter, Office‑wiskunde‑equaties hebben een belangrijke beperking. Als een vergelijking is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het originele **Cambria Math**‑lettertype nodig hebben om de lay-out van de vergelijking correct te berekenen en weer te geven. Hierdoor wordt het substitueren van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het weergeven van vergelijkingen en kan dit nog steeds resulteren in een uitzondering die aangeeft dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol te converteren, moet u ervoor zorgen dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. U kunt het lettertype installeren in het besturingssysteem of het beschikbaar stellen als een [extern lettertype](/slides/nl/python-net/custom-font/) zodat het kan deelnemen aan het normale lettertype‑selectieproces tijdens het renderen en converteren.

Deze beperking is specifiek voor het weergeven van vergelijkingen. De hierboven beschreven standaardregels voor lettertypevervanging zijn nog steeds van toepassing op reguliere presentatie‑tekst wanneer het originele lettertype ontoegankelijk is.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertypevervanging en lettertypesubstitutie?**

[Vervanging](/slides/nl/python-net/font-replacement/) is een geforceerde overschrijving van één lettertype met een ander voor de volledige presentatie. Substitutie is een regel die wordt geactiveerd onder een specifieke voorwaarde, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is, waarna een aangewezen reservé‑lettertype wordt gebruikt.

**Wanneer precies worden substitutieregels toegepast?**

De regels nemen deel aan de standaard [lettertype‑selectie](/slides/nl/python-net/font-selection-sequence/)‑reeks die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als noch vervanging noch substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek zal proberen het dichtstbijzijnde beschikbare systeem‑lettertype te kiezen, vergelijkbaar met hoe PowerPoint zich zou gedragen.

**Kan ik aangepaste externe lettertypen tijdens runtime toevoegen om substitutie te voorkomen?**

Ja. U kunt tijdens runtime [externe lettertypen toevoegen](/slides/nl/python-net/custom-font/) zodat de bibliotheek ze in aanmerking neemt voor selectie en weergave, inclusief voor daaropvolgende conversies.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. Aspose distribueert geen betaalde of gratis lettertypen; u voegt lettertypen toe en gebruikt ze op eigen inzicht en verantwoordelijkheid.

**Zijn er verschillen in substitutiegedrag op Windows, Linux en macOS?**

Ja. Het zoeken naar lettertypen begint in de font‑mappen van het besturingssysteem. De set van standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op beschikbaarheid en de noodzaak voor substitutie.

**Hoe moet ik de omgeving voorbereiden om onverwachte substitutie tijdens batch‑conversies te minimaliseren?**

Synchroniseer de verzameling lettertypen tussen machines of containers, [voeg de externe lettertypen](/slides/nl/python-net/custom-font/) toe die nodig zijn voor de uitvoerdocumenten, en [embed lettertypen](/slides/nl/python-net/embedded-font/) in presentaties waar mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.