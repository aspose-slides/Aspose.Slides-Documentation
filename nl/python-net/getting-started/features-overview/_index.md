---
title: "Overzicht van functies"
type: docs
weight: 20
url: /nl/python-net/features-overview/
keywords:
  - "functies"
  - "ondersteunde platforms"
  - "bestandsformaat"
  - "conversie"
  - "weergave"
  - "opmaak"
  - "PowerPoint"
  - "OpenDocument"
  - "presentatie"
  - "Python"
  - "Aspose.Slides"
description: "Ontdek Aspose.Slides for Python via .NET: een krachtige API om efficiënt PowerPoint- en OpenDocument‑presentaties te maken, bewerken, automatiseren en converteren."
---
## **Ondersteunde platforms**
De platforms waarop Aspose.Slides for Python via .NET kan worden gebruikt, zijn Windows x64 of x86 en een breed scala aan Linux‑distributies met Python 3.5 of hoger geïnstalleerd. Er zijn extra vereisten voor het doel‑Linux‑platform:

- GCC-6 runtime-bibliotheken (of later)
- Afhankelijkheden van de .NET Core Runtime. Het installeren van de .NET Core Runtime zelf is NIET vereist
- Voor Python 3.5-3.7: de `pymalloc`-build van Python is vereist. De `--with-pymalloc` Python-buildoptie is standaard ingeschakeld. Meestal wordt de `pymalloc`-build van Python gemarkeerd met de `m`-suffix in de bestandsnaam.
- `libpython` gedeelde Python‑bibliotheek. De `--enable-shared` Python‑buildoptie is standaard uitgeschakeld; sommige Python‑distributies bevatten de `libpython` gedeelde bibliotheek niet. Voor sommige Linux‑platformen kan de `libpython` gedeelde bibliotheek worden geïnstalleerd via de pakketbeheerder, bijvoorbeeld: `sudo apt-get install libpython3.7`. Het veelvoorkomende probleem is dat de `libpython`‑bibliotheek op een andere locatie is geïnstalleerd dan de standaard systeemlocatie voor gedeelde bibliotheken. Het probleem kan worden opgelost door de Python‑buildopties te gebruiken om alternatieve bibliotheekpaden in te stellen bij het compileren van Python, of door een symbolische link naar het `libpython`‑bibliotheekbestand te maken in de standaard locatie voor gedeelde bibliotheken. Meestal heeft het `libpython` gedeelde bibliotheekbestand de naam `libpythonX.Ym.so.1.0` voor Python 3.5-3.7, of `libpythonX.Y.so.1.0` voor Python 3.8 of later (bijvoorbeeld: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Als u ondersteuning voor meer platforms nodig heeft, kijk dan naar de “twin brother”‑producten Aspose.Slides for .NET of Aspose.Slides for Java.

## **Bestandsformaten en conversies**
Aspose.Slides for Python via .NET ondersteunt de meeste PowerPoint‑documentformaten. Het stelt u ook in staat ze te exporteren naar de populaire formaten die organisaties breed gebruiken en onderling uitwisselen. Bekijk deze details:

|**Functie**|**Beschrijving**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/nl/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET biedt de snelste verwerking voor dit presentatiedocumentformaat.|
|[PPT‑naar‑PPTX conversie](/slides/nl/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET ondersteunt de conversie van PPT naar PPTX.|
|[Portable Document Format (PDF)](/slides/nl/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|U kunt alle ondersteunde bestandsformaten met één methode exporteren naar Adobe Portable Document Format (PDF)-documenten.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-xps/)|U kunt alle ondersteunde bestandsformaten met één methode exporteren naar XML Parser Specification (XPS)-documenten.|
|[Tagged Image File Format (TIFF)](/slides/nl/python-net/convert-powerpoint-to-tiff/)|U kunt alle ondersteunde presentatiedocumentformaten exporteren naar Tagged Image File Format (TIFF).|
|[PPTX‑naar‑HTML conversie](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET ondersteunt de conversie van PresentationEx naar HTML-formaat.|

## **Presentatie-rendering**
Aspose.Slides for Python via .NET ondersteunt high‑fidelity rendering van dia's in presentatiedocumenten naar verschillende grafische formaten. Bekijk deze details:

|**Functie**|**Beschrijving**|
| :- | :- |
|Ondersteunde .NET-beeldformaten|Met Aspose.Slides for Python via .NET kunt u presentatiedia's en afbeeldingen op dia's renderen naar alle door .NET ondersteunde grafische formaten, zoals TIFF, PNG, BMP, JPEG, GIF en metafiles.|
|SVG‑formaat|Aspose.Slides for Python via .NET biedt ook ingebouwde methoden waarmee u presentatiedia's kunt exporteren naar Scalable Vector Graphics (SVG)-formaten.|

## **Inhoudsfuncties**
Aspose.Slides for Python via .NET stelt u in staat bijna alle items of inhoud van presentatiedocumenten te benaderen, wijzigen of aan te maken. Bekijk deze details:

|**Functie**|**Beschrijving**|
| :- | :- |
|Masterdia's|De masterdia's bepalen de lay-out van de normale dia's. Aspose.Slides for Python via .NET stelt u in staat de masterdia's van presentatiedocumenten te benaderen en te wijzigen.|
|Normale dia's|Met Aspose.Slides for Python via .NET kunt u nieuwe dia's van verschillende typen aanmaken; u kunt ook bestaande dia's in de presentaties benaderen en wijzigen.|
|Dupliceren / Kopiëren van dia's|Er zijn ingebouwde methoden beschikbaar in Aspose.Slides for Python via .NET waarmee u bestaande dia's binnen een presentatie kunt dupliceren of kopiëren. U kunt ook gekopieerde en gedupliceerde dia's van de ene presentatie naar de andere gebruiken. Omdat een dia zijn lay-out erft van de masterdia, kopiëren de ingebouwde duplicatiemethoden automatisch de master bij het dupliceren.|
|Beheren van dia‑secties|Methoden om dia's in verschillende secties binnen een presentatie te organiseren.|
|Plaathouders en Tekst‑houders|U kunt de plaatshouders en tekst‑houders in een dia benaderen. Bovendien kunt u met de juiste methode een dia met tekst‑houders vanaf nul aanmaken.|
|Koppen en voetteksten|Aspose.Slides for Python via .NET vergemakkelijkt het behandelen van koppen/voetteksten in dia's.|
|Notities in dia's|Met Aspose.Slides for Python via .NET kunt u notities die aan een dia zijn gekoppeld benaderen en wijzigen, en ook nieuwe notities toevoegen.|
|Vinden van een vorm|U kunt ook een specifieke vorm op een dia vinden met behulp van de alternatieve tekst die aan de vorm is gekoppeld.|
|Achtergronden|Aspose.Slides for Python via .NET stelt u in staat te werken met achtergronden die zijn gekoppeld aan een master- of normale dia in een presentatie.|
|Tekstvakken|Tekstvakken kunnen vanaf nul worden aangemaakt. U kunt bestaande tekstvakken benaderen. U kunt ook hun tekst aanpassen zonder het oorspronkelijke opmaak te verliezen.|
|Rechthoekige vormen|U kunt rechthoekige vormen aanmaken of wijzigen met Aspose.Slides for Python via .NET.|
|Poly‑lijn vormen|U kunt poly‑lijn vormen aanmaken of wijzigen met Aspose.Slides for Python via .NET.|
|Ellipsvormen|U kunt ellipsvormen aanmaken of wijzigen met Aspose.Slides for Python via .NET.|
|Groepsvormen|Aspose.Slides for Python via .NET ondersteunt groepsvormen|
|Auto‑vormen|Aspose.Slides for Python via .NET ondersteunt auto‑vormen|
|SmartArt|Aspose.Slides for Python via .NET biedt ondersteuning voor SmartArt‑vormen in MS PowerPoint|
|Grafieken|Aspose.Slides for Python via .NET biedt ondersteuning voor MSO‑grafieken in PowerPoint|
|Serialisatie van vormen|Aspose.Slides for Python via .NET ondersteunt een groot aantal vormen. Wanneer Aspose.Slides for Python via .NET geen ondersteuning biedt voor een vorm, kunt u een serialisatiemethode gebruiken waarmee u die vorm vanuit een bestaande dia serialiseert. Op deze manier kunt u de vorm later gebruiken volgens uw wensen.|
|Afbeeldingskaders|U kunt afbeeldingen in afbeeldingskaders beheren met Aspose.Slides for Python via .NET|
|Audio‑kaders|U kunt audio‑bestanden koppelen of insluiten in audio‑kaders op dia's met Aspose.Slides for Python via .NET|
|Video‑kaders|U kunt video‑bestanden beheren in video‑kaders. Aspose.Slides for Python via .NET biedt ook ondersteuning voor gekoppelde en ingesloten video's.|
|OLE‑kader|U kunt OLE‑objecten beheren in OLE‑kaders met Aspose.Slides for Python via .NET|
|Tabellen|Aspose.Slides for Python via .NET ondersteunt tabellen in dia's.|
|ActiveX‑besturingselementen|Ondersteuning voor ActiveX‑besturingselementen|
|VBA‑macro's|Ondersteuning voor het beheren van VBA‑macro's in presentaties.|
|Tekstkader|U kunt de tekst van elke vorm benaderen via het tekstkader dat aan die vorm is gekoppeld.|
|Tekstscannen|U kunt tekst scannen in een presentatie op presentatieniveau of dia‑niveau via ingebouwde scanmethoden.|
|Animaties|U kunt animaties toepassen op vormen.|
|Diavoorstellingen|Aspose.Slides for Python via .NET ondersteunt diavoorstellingen en dia‑overgangen.|

## **Opmaakfuncties**
Met Aspose.Slides for Python via .NET kunt u teksten en vormen op dia's in presentaties opmaken. Bekijk deze details:

|**Functie**|**Beschrijving**|
| :- | :- |
|Text Formatting|<p>In Aspose.Slides for Python via .NET kunt u teksten beheren via de tekstkaders die aan de vormen zijn gekoppeld. Hierdoor kunt u teksten opmaken met behulp van de alinea's en segmenten die bij de tekstkaders horen. Deze tekstelementen kunnen worden opgemaakt via Aspose.Slides for Python via .NET.</p><p>- Lettertype</p><p>- Lettergrootte</p><p>- Letterkleur</p><p>- Lettertinten</p><p>- Alinea‑uitlijning</p><p>- Alinea‑opsomming</p><p>- Alinea‑oriëntatie</p>|
|Shape Formatting|<p>In Aspose.Slides for Python via .NET is het basis­element van een dia een vorm. U kunt deze vormelementen opmaken met Aspose.Slides for Python via .NET:</p><p>- Positie</p><p>- Grootte</p><p>- Lijn</p><p>- Vulling (inclusief patroon, gradient, solid)</p><p>- Tekst</p><p>- Afbeelding</p>|

## **Veelgestelde vragen**

### Moet ik Microsoft PowerPoint op de server/PC installeren om de bibliotheek te laten werken?

Nee. PowerPoint is niet vereist; Aspose.Slides is een zelfstandige engine voor het maken, bewerken, converteren en renderen van presentaties.

### Hoe werkt multithreading? Kan verwerking parallel worden uitgevoerd?

Het is veilig om verschillende documenten in verschillende threads te verwerken; hetzelfde [presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) object mag niet gelijktijdig door [multiple threads](/slides/nl/python-net/multithreading/) worden gebruikt.

### Worden bestandswachtwoorden en encryptie ondersteund?

Ja. [You can](/slides/nl/python-net/password-protected-presentation/) versleutelde presentaties openen, een open‑ en schrijfwachtwoord instellen of verwijderen, en de beschermingsstatus controleren.

### Moet ik rekening houden met lettertype‑pakketten in Linux‑containers?

Ja. Het wordt aanbevolen om algemene lettertype‑pakketten te installeren en/of expliciet [specify font directories](/slides/nl/python-net/custom-font/) in uw applicatie te vermelden om onverwachte substituties te vermijden.

### Zijn er beperkingen in de evaluatieversie?

In [evaluation mode](/slides/nl/python-net/licensing/) wordt een watermerk aan de output toegevoegd en gelden bepaalde beperkingen; een [30‑day temporary license](https://purchase.aspose.com/temporary-license/) is beschikbaar voor volledige functionaliteitstesten.

### Is het importeren van externe formaten in een presentatie (PDF/HTML → PPTX) ondersteund?

Ja. U kunt [PDF pages and HTML content](/slides/nl/python-net/import-presentation/) aan een presentatie toevoegen, waardoor ze in dia's worden omgezet.