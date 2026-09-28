---
title: Installera Aspose.Slides för SharePoint
type: docs
weight: 10
url: /sv/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Installera Aspose.Slides för SharePoint på en SharePoint-farm: välj installationsprogrammet för din SharePoint-version, kör systemkontrollen och distribuera samt aktivera lösningen."
---
## **Paketinnehåll**

Aspose.Slides för SharePoint hämtas från [nedladdningssida](https://releases.aspose.com/slides/sharepoint/) som ett ZIP‑arkiv. Arkivet innehåller ett SharePoint‑lösningspaket (WSP) och ett installationsprogram för varje stödd SharePoint‑version:

| SharePoint‑version | Installationsprogram | Lösningspaket |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Varje installationsprogram har en konfigurationsfil bredvid sig (t.ex. *Setup2019.exe.config*) som anger vilket lösningspaket som installeras. Mappen *License* innehåller en länk till slutanvändarens licensavtal och tilläggslicensmeddelanden från tredje part.

Aspose.Slides för SharePoint paketeras som en SharePoint‑lösning, som SharePoint distribuerar över serverfarmen. Dess funktion aktiveras eller inaktiveras per webbplatskollektion.

## **Installationsprocessen**

Innan installationen kör installationsprogrammet en systemkontroll. Det verifierar att:

- SharePoint är installerat på servern.
- Den aktuella användaren har behörighet att installera och distribuera SharePoint‑lösningar.
- SharePoint‑Administration‑tjänsten är startad.
- SharePoint‑Timer‑tjänsten är startad.
- Lösningspaketet som anges i konfigurationsfilen är närvarande.

Administration‑ och Timer‑tjänsterna behövs eftersom vissa installationsåtgärder körs som timer‑jobb som sprider lösningen till alla servrar i farmen.

### **Köra installationen**

För att installera Aspose.Slides för SharePoint:

1. Packa upp ZIP‑arkivet till en lokal enhet på en server i SharePoint‑farm.
2. Kör installationsprogrammet som matchar din SharePoint‑version (se tabellen ovan) och följ anvisningarna på skärmen. Installationsprogrammet:
   1. Kör systemkontrollen. Installationen fortsätter inte om någon kontroll misslyckas.

      **Kör en systemkontroll**

      ![Systemkontrollskärmen för installationsprogrammet](installing-aspose-slides-for-sharepoint_1.png)

   2. Visar slutanvändarens licensavtal. Du måste godkänna det för att fortsätta.

      **Licensavtalet**

      ![Licensavtalsskärmen för installationsprogrammet](installing-aspose-slides-for-sharepoint_2.png)

   3. Visar distributionsmålen. Välj de webbapplikationer och webbplatskollektioner som funktionen ska aktiveras för.

      **Välja distributionsmål**

      ![Målskärmen för webbplatskollektion i installationsprogrammet](installing-aspose-slides-for-sharepoint_3.png)

   4. Distribuerar lösningen till farmen.

      **Installationsförloppet**

      ![Installationsprogressskärmen för installationsprogrammet](installing-aspose-slides-for-sharepoint_4.png)

   5. Aktiverar Aspose.Slides för SharePoint på de valda webbplatskollektionerna.
   6. Listar de webbapplikationer och webbplatskollektioner där lösningen har distribuerats och aktiverats.

      **Lyckad installation**

      ![Skärmen för slutförd installation i installationsprogrammet](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Skärmbilderna togs på SharePoint 2007. Installationsprogrammen för senare versioner går igenom samma skärmar.
{{% /alert %}}

Om samma version av Aspose.Slides för SharePoint redan är installerad, erbjuder installationsprogrammet att reparera eller ta bort den. Om en annan version är installerad, erbjuder det att uppgradera eller ta bort den.

Efter installationen visas ett **Convert via Aspose.Slides**‑objekt i menyen för filer i dokumentbiblioteken för de valda webbplatskollektionerna (på SharePoint 2007, **Convert with Aspose.Slides**). För att konvertera en första presentation, se [Konvertera Microsoft PowerPoint‑dokument till andra format](/slides/sv/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Vad lösningen lägger till i farmen beskrivs i [Distribution och aktivering](/slides/sv/sharepoint/deployment-and-activation/).

## **Vanliga frågor**

**Vilket installationsprogram ska jag köra?**

Det som har ett namn som matchar din SharePoint‑version. Till exempel, kör *Setup2016.exe* på en SharePoint Server 2016‑farm. Varje installationsprogram installerar endast sitt eget lösningspaket.

**Behöver jag en separat nedladdning för den licensierade versionen?**

Nej. Samma paket fungerar i utvärderingsläge tills du installerar licenslösningen; se [Installera Aspose.Slides för SharePoint‑licens](/slides/sv/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Hur tar jag bort produkten?**

Kör samma installationsprogram igen och välj **Remove**; se [Avinstallera Aspose.Slides för SharePoint](/slides/sv/sharepoint/uninstalling-aspose-slides-for-sharepoint/).