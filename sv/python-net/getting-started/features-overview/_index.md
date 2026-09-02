---
title: Översikt över funktioner
type: docs
weight: 20
url: /sv/python-net/features-overview/
keywords:
- funktioner
- stödjade plattformar
- filformat
- konvertering
- rendering
- formatering
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck Aspose.Slides for Python via .NET: ett kraftfullt API för att skapa, redigera, automatisera och konvertera PowerPoint- och OpenDocument-presentationer effektivt."
---
## **Supporterade plattformar**
Plattformarna Aspose.Slides for Python via .NET kan användas på Windows x64 eller x86 samt ett brett utbud av Linux-distributioner med Python 3.5 eller senare installerat. Det finns ytterligare krav på mål‑Linux‑plattformen:
- GCC‑6 runtime‑bibliotek (eller senare)
- Beroenden för .NET Core Runtime. Att installera .NET Core Runtime själv är INTE nödvändigt
- För Python 3.5‑3.7: `pymalloc`‑byggnaden av Python krävs. Python‑byggalternativet `--with-pymalloc` är aktiverat som standard. Vanligtvis markeras `pymalloc`‑byggnaden av Python med suffixet `m` i filnamnet.
- `libpython` delade Python‑bibliotek. Python‑byggalternativet `--enable-shared` är inaktiverat som standard, vissa Python‑distributioner innehåller inte det delade `libpython`‑biblioteket. För vissa Linux‑plattformar kan `libpython`‑biblioteket installeras via paketshanteraren, till exempel: `sudo apt-get install libpython3.7`. Vanligt problem är att `libpython`‑biblioteket installeras på en annan plats än den standardmässiga systemplatsen för delade bibliotek. Problemet kan åtgärdas genom att använda Python‑byggalternativen för att ange alternativa biblioteksökvägar vid kompilering av Python, eller genom att skapa en symbolisk länk till `libpython`‑biblioteksfilen i systemets standardplats för delade bibliotek. Vanligtvis är filnamnet för det delade `libpython`‑biblioteket `libpythonX.Ym.so.1.0` för Python 3.5‑3.7, eller `libpythonX.Y.so.1.0` för Python 3.8 eller senare (till exempel: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Om du behöver stöd för fler plattformar, se efter de “tvilling‑bröder” produkterna Aspose.Slides för .NET eller Aspose.Slides för Java.

## **Filformat och konverteringar**
Aspose.Slides for Python via .NET stöder de flesta PowerPoint-dokumentformat. Det låter dig också exportera dem till de populära format som organisationer ofta använder och utbyter med varandra. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/sv/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET erbjuder den snabbaste bearbetningen för detta presentationsdokumentformat.|
|[PPT till PPTX konvertering](/slides/sv/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET stödjer konvertering av PPT till PPTX.|
|[Portable Document Format (PDF)](/slides/sv/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Du kan exportera alla stödda filformat till Adobe Portable Document Format (PDF)-dokument med en enda metod.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-xps/)|Du kan exportera alla stödda filformat till XML Parser Specification (XPS)-dokument med en enda metod.|
|[Tagged Image File Format (TIFF)](/slides/sv/python-net/convert-powerpoint-to-tiff/)|Du kan exportera alla stödda presentationsfilformat till Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET stödjer konvertering av PresentationEx till HTML-format.|

## **Rendering av presentationer**
Aspose.Slides for Python via .NET stödjer rendering med hög precision av bilder i presentationsdokument till olika grafikformat. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|Bildformat som stöds av .NET|Med Aspose.Slides for Python via .NET kan du rendera presentationsbilder och bilder på bilder till alla .NET‑stödde grafikformat såsom TIFF, PNG, BMP, JPEG, GIF och metafiler.|
|SVG‑format|Aspose.Slides for Python via .NET tillhandahåller också inbyggda metoder som låter dig exportera presentationsbilder till Scalable Vector Graphics (SVG)-format.|

## **Innehållsfunktioner**
Aspose.Slides for Python via .NET låter dig komma åt, ändra eller skapa nästan alla objekt eller innehåll i presentationsdokument. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|Masterbilder|Masterbilderna definierar layouten för vanliga bilder. Aspose.Slides for Python via .NET låter dig komma åt och ändra masterbilderna i presentationsdokument.|
|Vanliga bilder|Med Aspose.Slides for Python via .NET kan du skapa nya bilder av olika typer; du kan också komma åt och ändra befintliga bilder i presentationerna.|
|Kloning / Kopiering av bilder|Det finns inbyggda metoder i Aspose.Slides for Python via .NET som låter dig klona eller kopiera befintliga bilder inom en presentation. Du kan även använda kopierade och klonade bilder från en presentation till en annan. Eftersom en bild ärver sin layout från masterbilden kopierar de inbyggda kloningsmetoderna automatiskt masterbilden vid kloning.|
|Hantera bildsektioner|Metoder för att organisera bilder i olika sektioner i en presentation.|
|Platshållare och texthållare|Du kan komma åt platshållare och texthållare i en bild. Dessutom kan du skapa en bild med texthållare från grunden med lämplig metod.|
|Sidhuvuden och sidfötter|Aspose.Slides for Python via .NET underlättar hantering av sidhuvuden/sidfötter i bilder.|
|Anteckningar i bilder|Med Aspose.Slides for Python via .NET kan du komma åt och ändra anteckningar som är kopplade till en bild samt lägga till nya anteckningar.|
|Hitta en form|Du kan också hitta en viss form i en bild med hjälp av den alternativa texten som är kopplad till formen.|
|Bakgrunder|Aspose.Slides for Python via .NET låter dig arbeta med bakgrunder som är kopplade till en master- eller normal bild i en presentation.|
|Textrutor|Textrutor kan skapas från grunden. Du kan komma åt befintliga textrutor. Du kan även ändra deras text utan att förlora originalformatet.|
|Rektangulära former|Du kan skapa eller ändra rektangulära former med Aspose.Slides for Python via .NET.|
|Polylinjeformer|Du kan skapa eller ändra polylinjeformer med Aspose.Slides for Python via .NET.|
|Ellipsformer|Du kan skapa eller ändra ellipsformer med Aspose.Slides for Python via .NET.|
|Gruppformer|Aspose.Slides for Python via .NET stödjer gruppformer.|
|Automatiska former|Aspose.Slides for Python via .NET stödjer automatiska former.|
|SmartArt|Aspose.Slides for Python via .NET erbjuder stöd för SmartArt‑former i MS PowerPoint.|
|Diagram|Aspose.Slides for Python via .NET erbjuder stöd för MSO‑diagram i PowerPoint.|
|Serialisering av former|Aspose.Slides for Python via .NET stöder ett stort antal former. När Aspose.Slides for Python via .NET saknar stöd för en form kan du använda en serialiseringsmetod för att serialisera den formen från en befintlig bild. På så sätt kan du återanvända formen enligt dina krav.|
|Bildramar|Du kan hantera bilder i bildramar med Aspose.Slides for Python via .NET.|
|Ljudramar|Du kan länka eller bädda in ljudfiler i ljudramar på bilder med Aspose.Slides for Python via .NET.|
|Video‑ramar|Du kan hantera videofiler i videoramar. Aspose.Slides for Python via .NET erbjuder även stöd för länkade och inbäddade videor.|
|OLE‑ram|Du kan hantera OLE‑objekt i OLE‑ramar med Aspose.Slides for Python via .NET.|
|Tabeller|Aspose.Slides for Python via .NET stödjer tabeller i bilder.|
|ActiveX‑kontroller|Stöd för ActiveX‑kontroller.|
|VBA‑makron|Stöd för hantering av VBA‑makron i presentationer.|
|Textram|Du kan få åtkomst till texten i vilken form som helst via textramen som är kopplad till den formen.|
|Textsökning|Du kan söka igenom text i en presentation på presentations‑ eller bildnivå med inbyggda sökmetoder.|
|Animationer|Du kan applicera animationer på former.|
|Bildspel|Aspose.Slides for Python via .NET stödjer bildspel och bildövergångar.|

## **Formateringsfunktioner**
Med Aspose.Slides for Python via .NET kan du formatera text och former på bilder i presentationer. Gå igenom dessa detaljer:

|**Funktion**|**Beskrivning**|
| :- | :- |
|Textformatering|<p>I Aspose.Slides for Python via .NET kan du hantera texter via textramarna som är kopplade till formerna. Därmed kan du formatera texter med hjälp av stycken och delar som är associerade med textramarna. Dessa textelement kan formateras via Aspose.Slides for Python via .NET.</p><p>- Typsnittstyp</p><p>- Teckenstorlek</p><p>- Teckens färg</p><p>- Teckens nyanser</p><p>- Styckejustering</p><p>- Punktlista i stycke</p><p>- Styckeretning</p>|
|Formatering av former|<p>I Aspose.Slides for Python via .NET är grundelementet i en bild en form. Du kan formatera dessa formelement med Aspose.Slides for Python via .NET:</p><p>- Position</p><p>- Storlek</p><p>- Linje</p><p>- Fyll (inklusive mönster, gradient, solid)</p><p>- Text</p><p>- Bild</p>|

## **FAQ**

### Behöver jag installera Microsoft PowerPoint på servern/PC:n för att biblioteket ska fungera?
Nej. PowerPoint krävs inte; Aspose.Slides är en fristående motor för att skapa, redigera, konvertera och rendera presentationer.

### Hur fungerar multitrådning? Kan bearbetning parallelliseras?
Det är säkert att bearbeta olika dokument i olika trådar; samma [presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-objekt får inte användas av [flera trådar](/slides/sv/python-net/multithreading/) samtidigt.

### Stöds fillösenord och kryptering?
Ja. [Du kan](/slides/sv/python-net/password-protected-presentation/) öppna krypterade presentationer, ange eller ta bort ett öppnings‑ och skrivlösenord samt kontrollera skyddsstatusen.

### Måste jag ta hänsyn till teckensnittspaket i Linux‑containrar?
Ja. Det rekommenderas att installera vanliga teckensnittspaket och/eller uttryckligen [ange teckensnittskataloger](/slides/sv/python-net/custom-font/) i din applikation för att undvika oväntade ersättningar.

### Finns det begränsningar i utvärderingsversionen?
I [utvärderingsläge](/slides/sv/python-net/licensing/) läggs ett vattenmärke till i utskriften och vissa begränsningar gäller; en [30‑dagars tillfällig licens](https://purchase.aspose.com/temporary-license/) finns tillgänglig för fullständig funktionsgranskning.

### Stöds import av externa format till en presentation (PDF/HTML → PPTX)?
Ja. Du kan lägga till [PDF‑sidor och HTML‑innehåll](/slides/sv/python-net/import-presentation/) i en presentation, vilket omvandlar dem till bilder.