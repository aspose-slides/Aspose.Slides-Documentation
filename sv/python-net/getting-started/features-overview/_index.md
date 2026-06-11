---
title: Översikt över funktioner
type: docs
weight: 20
url: /sv/python-net/features-overview/
keywords:
- funktioner
- stödda plattformar
- filformat
- konvertering
- rendering
- utskrift
- formatering
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides for Python via .NET: ett kraftfullt API för att skapa, redigera, automatisera och konvertera PowerPoint- och OpenDocument-presentationer effektivt."
---
## **Stödda plattformar**
Plattformarna som Aspose.Slides for Python via .NET kan användas på Windows x64 eller x86 samt på ett brett utbud av Linux‑distributioner med Python 3.5 eller senare installerat. Det finns ytterligare krav på mål‑Linux‑plattformen:
- GCC‑6 runtime‑bibliotek (eller senare)
- Beroenden för .NET Core Runtime. Att installera .NET Core Runtime själv är **inte** obligatoriskt
- För Python 3.5‑3.7: `pymalloc`‑byggnaden av Python behövs. Byggalternativet `--with-pymalloc` är aktiverat som standard. Vanligtvis markeras `pymalloc`‑byggnaden med suffixet `m` i filnamnet.
- `libpython`‑delad Python‑bibliotek. Byggalternativet `--enable-shared` är inaktiverat som standard, vissa Python‑distributioner innehåller inte `libpython`‑biblioteket. På vissa Linux‑plattformar kan `libpython`‑biblioteket installeras via pakethanteraren, till exempel: `sudo apt-get install libpython3.7`. Vanligt problem är att `libpython`‑biblioteket installeras på en annan plats än den standardiserade systemplatsen för delade bibliotek. Problemet kan åtgärdas genom att använda Python‑byggalternativ för att ange alternativa bibliotekssökvägar vid kompilering, eller genom att skapa en symbolisk länk till `libpython`‑biblioteket i systemets standardkatalog för delade bibliotek. Vanligt är att filnamnet på `libpython`‑biblioteket är `libpythonX.Ym.so.1.0` för Python 3.5‑3.7, eller `libpythonX.Y.so.1.0` för Python 3.8 eller senare (t.ex. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Om du behöver stöd för fler plattformar, se de “tvilling‑bröderna” Aspose.Slides for .NET eller Aspose.Slides for Java.

## **Filformat och konverteringar**
Aspose.Slides for Python via .NET stödjer de flesta PowerPoint‑dokumentformat. Det låter dig också exportera dem till de populära format som organisationer ofta använder och utbyter. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/sv/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET erbjuder den snabbaste bearbetningen för detta presentationsdokumentformat.|
|[PPT to PPTX conversion](/slides/sv/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET stöder konvertering från PPT till PPTX.|
|[Portable Document Format (PDF)](/slides/sv/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Du kan exportera alla stödda filformat till Adobe Portable Document Format (PDF) med en enda metod.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-xps/)|Du kan exportera alla stödda filformat till XML Parser Specification (XPS) med en enda metod.|
|[Tagged Image File Format (TIFF)](/slides/sv/python-net/convert-powerpoint-to-tiff/)|Du kan exportera alla stödda presentationsfilformat till Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET stöder konvertering av PresentationEx till HTML‑format.|

## **Rendering och utskrift**
Aspose.Slides for Python via .NET stödjer högkvalitativ rendering av bildspel i presentationsdokument till olika grafikformat. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|.NET‑stödda bildformat|Med Aspose.Slides for Python via .NET kan du rendera presentationsbilder och bilder på slides till alla .NET‑stödda grafikformat såsom TIFF, PNG, BMP, JPEG, GIF och metafiler.|
|SVG‑format|Aspose.Slides for Python via .NET erbjuder dessutom inbyggda metoder som låter dig exportera presentationsbilder till Scalable Vector Graphics (SVG).|
|Utskrift av presentation|De senaste versionerna av Aspose.Slides for Python via .NET tillhandahåller inbyggda utskriftsmetoder med olika alternativ.|

## **Innehållsfunktioner**
Aspose.Slides for Python via .NET låter dig komma åt, ändra eller skapa nästan alla objekt eller innehåll i presentationsdokument. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|Master Slides|Master‑slides definierar layouten för vanliga slides. Aspose.Slides for Python via .NET låter dig komma åt och ändra master‑slides i presentationsdokument.|
|Normal Slides|Med Aspose.Slides for Python via .NET kan du skapa nya slides av olika typer; du kan också komma åt och ändra befintliga slides i presentationerna.|
|Cloning / Copying Slides|Det finns inbyggda metoder i Aspose.Slides for Python via .NET som låter dig klona eller kopiera befintliga slides inom en presentation. Du kan också använda kopierade och klonade slides från en presentation till en annan. Eftersom en slide ärver sin layout från master‑sliden kopierar de inbyggda kloningsmetoderna automatiskt master‑sliden vid kloning.|
|Managing Slides sections|Metoder för att organisera slides i olika avsnitt inom en presentation.|
|Place Holders and Text Holders|Du kan komma åt platshållare och texthållare i en slide. Dessutom kan du skapa en slide med texthållare från grunden med rätt metod.|
|Header and Footers|Aspose.Slides for Python via .NET underlättar hantering av sidhuvuden/sidfötter i slides.|
|Notes in Slides|Med Aspose.Slides for Python via .NET kan du komma åt och ändra anteckningar kopplade till en slide samt lägga till nya anteckningar.|
|Finding a Shape|Du kan även hitta en specifik form på en slide med hjälp av alternativ text som är associerad med formen.|
|Backgrounds|Aspose.Slides for Python via .NET låter dig arbeta med bakgrunder som är kopplade till en master‑ eller normal‑slide i en presentation.|
|Text Boxes|Textrutor kan skapas från grunden. Du kan komma åt befintliga textrutor. Du kan också ändra deras texter utan att förlora det ursprungliga textformatet.|
|Rectangle Shapes|Du kan skapa eller ändra rektangelformer med Aspose.Slides for Python via .NET.|
|Poly Line Shapes|Du kan skapa eller ändra polylinjeformer med Aspose.Slides for Python via .NET.|
|Ellipse Shapes|Du kan skapa eller ändra ellipsformer med Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET stödjer gruppformer.|
|Auto Shapes|Aspose.Slides for Python via .NET stödjer automatiska former.|
|SmartArt|Aspose.Slides for Python via .NET erbjuder stöd för SmartArt‑former i MS PowerPoint.|
|Charts|Aspose.Slides for Python via .NET erbjuder stöd för MSO‑diagram i PowerPoint.|
|Shapes Serialization|Aspose.Slides for Python via .NET stödjer ett stort antal former. När Aspose.Slides for Python via .NET saknar stöd för en viss form kan du använda en serialiseringsmetod för att serialisera den formen från en befintlig slide. På så sätt kan du återanvända formen enligt dina krav.|
|Picture Frames|Du kan hantera bilder i bildramar med Aspose.Slides for Python via .NET.|
|Audio Frames|Du kan länka eller bädda in ljudfiler i ljudramar på slides med Aspose.Slides for Python via .NET.|
|Video Frames|Du kan hantera videofiler i videoramar. Aspose.Slides for Python via .NET erbjuder också stöd för länkade och inbäddade videor.|
|OLE Frame|Du kan hantera OLE‑objekt i OLE‑ramar med Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET stödjer tabeller i slides.|
|ActiveX Controls|Stöd för ActiveX‑kontroller.|
|VBA Macros|Stöd för hantering av VBA‑makron i presentationer.|
|Text Frame|Du kan komma åt text i vilken form som helst via den textram som är kopplad till formen.|
|Text Scanning|Du kan skanna text i en presentation på presentations‑ eller slidnivå med inbyggda skanningsmetoder.|
|Animations|Du kan applicera animationer på former.|
|Slide Shows|Aspose.Slides for Python via .NET stödjer bildspelsvisningar och slide‑övergångar.|

## **Formateringsfunktioner**
Med Aspose.Slides for Python via .NET kan du formatera texter och former på slides i presentationer. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|Textformatering|<p>I Aspose.Slides for Python via .NET kan du hantera texter via de textram som är kopplade till formerna. Därmed kan du formatera texter med hjälp av stycken och delar som är associerade med textramen. Dessa textelement kan formateras genom Aspose.Slides for Python via .NET.</p><p>- Typsnittstyp</p><p>- Teckenstorlek</p><p>- Teckenfärg</p><p>- Teckennyanser</p><p>- Styckejustering</p><p>- Styckelistning</p><p>- Styckeorientering</p>|
|Formatering av former|<p>I Aspose.Slides for Python via .NET är den grundläggande enheten i en slide en form. Du kan formatera dessa formelement med Aspose.Slides for Python via .NET:</p><p>- Position</p><p>- Storlek</p><p>- Linje</p><p>- Fyllning (inklusive mönster, gradient, solid)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

**Behöver jag installera Microsoft PowerPoint på servern/PC:n för att biblioteket ska fungera?**

Nej. PowerPoint är inte nödvändigt; Aspose.Slides är en fristående motor för att skapa, redigera, konvertera och rendera presentationer.

**Hur fungerar multitrådad körning? Kan bearbetning parallelliseras?**

Det är säkert att bearbeta olika dokument i olika trådar; samma [presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt får inte användas av [multiple threads](/slides/sv/python-net/multithreading/) samtidigt.

**Stöds fillösenord och kryptering?**

Ja. Du kan [öppna](/slides/sv/python-net/password-protected-presentation/) krypterade presentationer, ange eller ta bort öppnings‑ och skrivlösenord samt kontrollera skyddstillståndet.

**Måste jag tänka på teckensnittspaket i Linux‑behållare?**

Ja. Det rekommenderas att installera vanliga teckensnittspaket och/eller uttryckligen [ange teckensnittskataloger](/slides/sv/python-net/custom-font/) i din applikation för att undvika oväntade ersättningar.

**Finns det begränsningar i utvärderingsversionen?**

I [utvärderingsläge](/slides/sv/python-net/licensing/) läggs ett vattenmärke till i utdata och vissa begränsningar gäller; en [30‑dagars temporär licens](https://purchase.aspose.com/temporary-license/) finns tillgänglig för fullständig funktionstestning.

**Stöds import av externa format till en presentation (PDF/HTML → PPTX)?**

Ja. Du kan lägga till [PDF‑sidor och HTML‑innehåll](/slides/sv/python-net/import-presentation/) i en presentation och omvandla dem till slides.