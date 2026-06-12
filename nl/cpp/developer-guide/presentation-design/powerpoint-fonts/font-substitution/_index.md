---
title: Lettertypevervanging configureren in presentaties met C++
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/cpp/font-substitution/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Schakel optimale lettertypevervanging in Aspose.Slides voor C++ in bij het converteren van PowerPoint- en OpenDocument-presentaties naar andere bestandsformaten."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een ander lettertype te gebruiken wanneer het oorspronkelijke lettertype van de presentatie niet beschikbaar is tijdens het renderen of converteren. Je kunt controleren welke lettertypen zijn vervangen door de `GetSubstitutions`-methode van de `IFontsManager`-interface te gebruiken.

Aspose.Slides biedt ook de mogelijkheid om regels voor lettertypevervanging te definiëren. Bijvoorbeeld, je kunt opgeven dat een ontoegankelijk lettertype moet worden vervangen door een ander beschikbaar lettertype en vervolgens die regels toepassen via de lettertypebeheerder van de presentatie.

## **Lettertypevervangingsregels instellen**

Aspose.Slides stelt je in staat regels voor lettertypen in te stellen die bepalen wat er moet gebeuren onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is) op de volgende manier:

1. Laad de betreffende presentatie.
2. Laad het lettertype dat vervangen zal worden.
3. Laad het nieuwe lettertype.
4. Voeg een regel toe voor de vervanging.
5. Voeg de regel toe aan de collectie van vervangingsregels voor lettertypes van de presentatie.
6. Genereer de dia-afbeelding om het effect te observeren.

Deze C++-code demonstreert het proces van lettertypevervanging:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Laadt een presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definieert het lettertype dat zal worden vervangen en het nieuwe lettertype
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Voegt een lettertype‑regel toe voor lettertypevervanging
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Voegt de regel toe aan de collectie van lettertype‑vervangingsregels
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Voegt de collectie van lettertype‑regels toe aan de regelslijst
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Slaat PPTX op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Je wilt misschien [**Lettertypevervanging**](/slides/nl/cpp/font-replacement/). 
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking-lettertypen**

Lettertypevervangingsregels nemen deel aan het standaard lettertype-selectieproces dat wordt gebruikt tijdens het renderen en converteren. Ze zijn geschikt voor gewone tekstscenario's waarbij Aspose.Slides een ontoegankelijk lettertype kan vervangen door een ander beschikbaar lettertype volgens de geconfigureerde regel.

Echter, Office-wiskundige vergelijkingen hebben een belangrijke beperking. Als een vergelijking is gemaakt met **Cambria Math**, kan Aspose.Slides nog steeds het oorspronkelijke **Cambria Math**-lettertype nodig hebben om de lay-out van de vergelijking correct te berekenen en weer te geven. Hierdoor wordt het vervangen van **Cambria Math** door een ander wiskundig lettertype, zoals **STIX Two Math**, niet ondersteund voor het renderen van vergelijkingen en kan er nog steeds een uitzondering optreden die aangeeft dat **Cambria Math** vereist is.

Om dergelijke presentaties succesvol om te zetten, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides tijdens runtime. Je kunt het lettertype installeren in het besturingssysteem of het aanbieden als een [extern lettertype](/slides/nl/cpp/custom-font/) zodat het kan deelnemen aan het normale lettertype-selectieproces tijdens het renderen en converteren.

Deze beperking is specifiek voor het renderen van vergelijkingen. De hierboven beschreven standaard lettertypevervangingsregels blijven van toepassing op gewone presentatietekst wanneer het oorspronkelijke lettertype ontoegankelijk is.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertypesubstitutie?**

[Vervanging](/slides/nl/cpp/font-replacement/) is een gedwongen overschrijving van het ene lettertype door een ander in de hele presentatie. Substitutie is een regel die wordt geactiveerd onder een specifieke voorwaarde, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is, en dan wordt een aangewezen alternatief lettertype gebruikt.

**Wanneer worden substitutieregels precies toegepast?**

De regels nemen deel aan de standaard [lettertype-selectie](/slides/nl/cpp/font-selection-sequence/) volgorde die wordt geëvalueerd tijdens het laden, renderen en converteren; als het gekozen lettertype niet beschikbaar is, wordt vervanging of substitutie toegepast.

**Wat is het standaardgedrag als er geen vervanging of substitutie is geconfigureerd en het lettertype ontbreekt op het systeem?**

De bibliotheek zal proberen het dichtstbijzijnde beschikbare systeemlettertype te kiezen, vergelijkbaar met hoe PowerPoint zich gedraagt.

**Kan ik aangepaste externe lettertypen tijdens runtime toevoegen om substitutie te voorkomen?**

Ja. Je kunt tijdens runtime [externe lettertypen toevoegen](/slides/nl/cpp/custom-font/) zodat de bibliotheek ze meeneemt bij de selectie en het renderen, ook voor latere conversies.

**Verstrekt Aspose enige lettertypen met de bibliotheek?**

Nee. Aspose levert geen betaalde of gratis lettertypen; je voegt zelf lettertypen toe en gebruikt ze naar eigen inzicht en verantwoordelijkheid.

**Zijn er verschillen in substitutiegedrag op Windows, Linux en macOS?**

Ja. Het zoeken naar lettertypen start in de lettertype-mappen van het besturingssysteem. De set standaard beschikbare lettertypen en de zoekpaden verschillen per platform, wat invloed heeft op de beschikbaarheid en de noodzaak voor substitutie.

**Hoe moet ik de omgeving voorbereiden om onverwachte substitutie tijdens batchconversies te minimaliseren?**

Synchroniseer de set lettertypen over machines of containers, [voeg de benodigde externe lettertypen toe](/slides/nl/cpp/custom-font/) voor de uitvoerdocumenten, en [embed lettertypen](/slides/nl/cpp/embedded-font/) in presentaties waar mogelijk zodat de gekozen lettertypen beschikbaar zijn tijdens het renderen.