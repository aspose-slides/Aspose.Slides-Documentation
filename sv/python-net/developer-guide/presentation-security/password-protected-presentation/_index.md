---
title: "Säkra presentationer med lösenord med Python"
linktitle: "Lösenordsskydd"
type: docs
weight: 20
url: /sv/python-net/password-protected-presentation/
keywords:
- låsa PowerPoint
- låsa presentation
- låsa upp PowerPoint
- låsa upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägga till lösenord
- kryptera PowerPoint
- kryptera presentation
- dekryptera PowerPoint
- dekryptera presentation
- skrivskydd
- PowerPoint-säkerhet
- presentationssäkerhet
- ta bort lösenord
- ta bort skydd
- ta bort kryptering
- inaktivera lösenord
- inaktivera skydd
- ta bort skrivskydd
- PowerPoint-presentation
- Python
- Aspose.Slides
description: "Lär dig hur du enkelt låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Öka din produktivitet och säkra dina presentationer med vår steg-för-steg-guide."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du anger ett lösenord som upprätthåller vissa begränsningar för presentationen. För att ta bort begränringarna måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att upprätthålla dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna modifiera din presentation kan du ställa in en modifieringsrestriktion. Restriktionen hindrar personer från att modifiera, ändra eller kopiera saker i din presentation (om de inte anger lösenordet). 

  Men i detta fall, även utan lösenordet, kan en användare komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren se innehållet eller saker – hyperlänkar, animationer, effekter och annat – i din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ställa in en öppningsrestriktion. Restriktionen hindrar personer från ens att visa innehållet i din presentation (om de inte anger lösenordet).

  Tekniskt hindrar öppningsrestriktionen även användare från att modifiera dina presentationer: När personer inte kan öppna en presentation kan de inte göra modifieringar eller ändringar i den. 

  **Obs** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## Så skyddar du en presentation med lösenord online

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock) sida. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicka på **Drop or upload your files**.

3. Välj den fil du vill lösenordsskydda på din dator. 

4. Ange ditt föredragna lösenord för redigeringsskydd; Ange ditt föredragna lösenord för visningsskydd. 

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, markera kryssrutan **Markera som slutgiltig**.

6. Klicka på **SKYDDA NU.** 

7. Klicka på **LADDA NER NU.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stöder lösenordsskydd, kryptering och liknande åtgärder för presentationer i följande format: 

- PPTX och PPT – Microsoft PowerPoint-presentation 
- ODP – OpenDocument-presentation 
- OTP – OpenDocument-presentationmall 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd på en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att sedan modifiera den låsta presentationen måste en användare ange lösenordet.

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen. 

Denna exempelkod visar hur du krypterar en presentation:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställa in skrivskydd på en presentation** 

Du kan lägga till en markering med text ”Gör inga ändringar” på en presentation. På så sätt kan du meddela användarna att du inte vill att de ska göra ändringar i presentationen.  

**Obs** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare—om de verkligen vill—modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att ange ett skrivskydd måste du använda setWriteProtection‑metoden. Denna exempelkod visar hur du ställer in skrivskydd på en presentation:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Dekryptera en presentation; öppna en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [remove_encryption](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/) utan några parametrar. Därefter måste du ange rätt lösenord för att läsa in presentationen. 

Denna exempelkod visar hur du dekrypterar en presentation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Ta bort kryptering; inaktivera lösenordsskydd**

Du kan ta bort kryptering eller lösenordsskydd på en presentation. På så sätt kan användare komma åt eller modifiera presentationen utan begränsningar. 

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

Du kan använda Aspose.Slides för att ta bort skrivskyddet som används på en presentationsfil. På så sätt kan användare modifiera som de vill – och de får inga varningar när de utför sådana uppgifter.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [remove_write_protection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/). Denna exempelkod visar hur du tar bort skrivskyddet från en presentation:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som gör att du kan lösenordsskydda en presentation samtidigt som användare fortfarande kan komma åt dess egenskaper.

**Obs:** Som standard, när Aspose.Slides krypterar en presentation, är presentationens dokumentegenskaper också lösenordsskyddade. Om du behöver göra dokumentegenskaperna tillgängliga även efter kryptering, låter Aspose.Slides dig göra exakt så.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, sätt egenskapen `encrypt_document_properties` i [ProtectionManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/) till `False`. Denna exempelkod visar hur du krypterar en presentation samtidigt som du ger användarna åtkomst till dess dokumentegenskaper:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/)‑objekt och sätt [only_load_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/only_load_document_properties/) till `True`. I detta läge ignorerar Aspose.Slides lösenordet och laddar endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda dokumentegenskaper och listar anpassade dokumentegenskaper via [Presentation.document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Läs inbyggda dokumentegenskaper.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Lista anpassade dokumentegenskaper.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (publika) när presentationen krypterades. Om dokumentegenskaperna är krypterade orsakar en inställning av `only_load_document_properties` till `True` ett undantag eftersom lösenordet ignoreras i detta läge. För att komma åt krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt `password`‑värde i [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/).

## **Kontrollera om en presentation är lösenordsskyddad innan den laddas**

Innan du laddar en presentation kan du vilja kontrollera och bekräfta att presentationen inte har skyddats med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation laddas utan dess lösenord.

Denna Python‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att ladda själva presentationen):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [is_encrypted](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/), som returnerar `True` om presentationen är krypterad eller `False` om den inte är krypterad.

Denna exempelkod visar hur du kontrollerar om en presentation är krypterad:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [is_write_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/), som returnerar `True` om presentationen är skrivskyddad eller `False` om den inte är skrivskyddad.

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
    # kontrollera om "pass" matchas med
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Den returnerar `True` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `False`.

{{% alert color="primary" title="Se också" %}} 
- [Digital signatur i PowerPoint](/slides/sv/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Vanliga frågor**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stöder moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av dataskydd för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när du försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket meddelar att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppnings‑ och sparandeoperationer. I de flesta fall är denna prestandapåverkan minimal och har inte någon betydande inverkan på den totala bearbetningstiden för dina presentationsuppgifter.