---
title: Säkra presentationer med lösenord med Python
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/python-net/password-protected-presentation/
keywords:
- lås PowerPoint
- lås presentation
- lås upp PowerPoint
- lås upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägg till lösenord
- kryptera PowerPoint
- kryptera presentation
- dekryptera PowerPoint
- dekryptera presentation
- skrivskydd
- PowerPoint säkerhet
- presentationssäkerhet
- ta bort lösenord
- ta bort skydd
- ta bort kryptering
- inaktivera lösenord
- inaktivera skydd
- ta bort skrivskydd
- PowerPoint presentation
- Python
- Aspose.Slides
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Öka din produktivitet och säkra dina presentationer med vår steg-för-steg-guide."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du anger ett lösenord som påtvingar vissa begränsningar för presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att påtvinga dessa begränsningar för en presentation:

- **Modifiering**

  Om du vill att bara vissa användare ska kunna ändra din presentation kan du ange en ändringsbegränsning. Begränsningen hindrar personer från att modifiera, ändra eller kopiera saker i din presentation (såvida de inte anger lösenordet).

  I detta fall kan en användare ändå komma åt ditt dokument och öppna det utan lösenord. I detta skrivskyddade läge kan användaren visa innehållet eller element—hyperlänkar, animationer, effekter och annat—i presentationen, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

  Om du vill att bara vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Begränsningen hindrar personer från att ens se innehållet i presentationen (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen också att användare ändrar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den.

  **Observera** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## Hur du lösenordsskyddar en presentation online

1. Gå till vår sida [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Klicka **Drop or upload your files**.

3. Välj den fil du vill lösenordsskydda på din dator.

4. Ange ditt föredragna lösenord för redigering; Ange ditt föredragna lösenord för visning.

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, kryssa i kryssrutan **Mark as final**.

6. Klicka **PROTECT NOW.**

7. Klicka **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande operationer för presentationer i följande format:

- PPTX och PPT – Microsoft PowerPoint‑presentation
- ODP – OpenDocument‑presentation
- OTP – OpenDocument‑presentationsmall

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra ändringar på följande sätt:

- Kryptera en presentation
- Ange skrivskydd för en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter som rör lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att ändra den låsta presentationen måste en användare ange lösenordet.

För att kryptera eller lösenordsskydda en presentation måste du använda metoden `encrypt` (från [ProtectionManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/)) för att ange ett lösenord för presentationen. Du skickar lösenordet till `encrypt`‑metoden och använder `save`‑metoden för att spara den nu krypterade presentationen.

Denna exempelkod visar hur du krypterar en presentation:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange skrivskydd för en presentation**

Du kan lägga till en markering med texten “Do not modify” i en presentation. På så sätt kan du tala om för användarna att du inte vill att de ska göra ändringar i presentationen.

**Observera** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare—om de verkligen vill—ändra presentationen, men för att spara ändringarna måste de skapa en ny presentation med ett annat namn.

För att ange skrivskydd måste du använda metoden `setWriteProtection`. Denna exempelkod visar hur du sätter skrivskydd för en presentation:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Dekryptera en presentation; öppna en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att skicka dess lösenord. För att dekryptera en presentation måste du anropa metoden [remove_encryption](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/) utan parametrar. Du kommer sedan att behöva ange rätt lösenord för att läsa in presentationen.

Denna exempelkod visar hur du dekrypterar en presentation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Ta bort kryptering; inaktivera lösenordsskydd**

Du kan ta bort kryptering eller lösenordsskydd på en presentation. På så sätt kan användare få åtkomst till eller ändra presentationen utan begränsningar.

För att ta bort kryptering eller lösenordsskydd måste du anropa metoden [remove_encryption](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/). Denna exempelkod visar hur du tar bort kryptering från en presentation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som använts på en presentationsfil. På så sätt kan användare redigera fritt—utan varningsmeddelanden när de utför sådana åtgärder.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [remove_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/). Denna exempelkod visar hur du tar bort skrivskyddet från en presentation:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta egenskaperna för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som du behåller möjligheten för användare att komma åt presentationens egenskaper.

**Observera** att när Aspose.Slides krypterar en presentation blir dokumentegenskaperna för presentationen också lösenordsskyddade som standard. Men om du vill göra presentationens egenskaper tillgängliga (även efter att presentationen har krypterats) tillåter Aspose.Slides dig att göra exakt det.

Om du vill att användare ska behålla möjlighet att komma åt egenskaperna för en presentation du krypterat kan du sätta egenskapen [EncryptDocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/) till `True`. Denna exempelkod visar hur du krypterar en presentation samtidigt som du ger användarna möjlighet att läsa dess dokumentegenskaper:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Kontrollera om en presentation är lösenordsskyddad innan du läser in den**

Innan du läser in en presentation kanske du vill kontrollera och bekräfta att presentationen inte är skyddad med lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation läses in utan dess lösenord.

Denna Python‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in själva presentationen):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra denna uppgift kan du använda egenskapen [is_encrypted](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/), som returnerar `True` om presentationen är krypterad eller `False` om den inte är krypterad.

Denna exempelkod visar hur du kontrollerar om en presentation är krypterad:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra denna uppgift kan du använda egenskapen [is_write_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/), som returnerar `True` om presentationen är krypterad eller `False` om den inte är krypterad.

Denna exempelkod visar hur du kontrollerar om en presentation är skrivskyddad:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validera eller bekräfta att ett specifikt lösenord har använts för att skydda en presentation**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller medel för att validera ett lösenord.

Denna exempelkod visar hur du validerar ett lösenord:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # kontrollera om "pass" matchar
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Den returnerar `True` om presentationen har krypterats med det angivna lösenordet. Annars returneras `False`.

{{% alert color="primary" title="See also" %}} 
- [Digital signatur i PowerPoint](/slides/sv/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög säkerhetsnivå för dina presentationer.

**Vad händer om ett felaktigt lösenord skrivs in när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan vid arbete med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppning och sparande. I de flesta fall är påverkan minimal och påverkar inte avsevärt den totala bearbetningstiden för dina presentationsuppgifter.