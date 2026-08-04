---
title: Presentaties beveiligen met wachtwoorden met Python
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/python-net/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beschermen
- presentatie beschermen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbeveiliging
- PowerPoint beveiliging
- presentatie beveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeveiliging verwijderen
- PowerPoint presentatie
- Python
- Aspose.Slides
description: "Leer hoe je moeiteloos password-beveiligde PowerPoint- en OpenDocument-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor Python via .NET. Verhoog je productiviteit en beveilig je presentaties met onze stapsgewijze gids."
---
## **Introductie**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Typisch kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Aanpassing**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen aanpassen, kun je een aanpassingsbeperking instellen. Deze beperking voorkomt dat mensen de presentatie wijzigen, veranderen of kopiëren (tenzij ze het wachtwoord invoeren).

  Echter, in dit geval kan een gebruiker, zelfs zonder wachtwoord, je document wel openen. In deze alleen‑lezen-modus kan de gebruiker de inhoud bekijken – hyperlinks, animaties, effecten en andere elementen – maar hij kan geen items kopiëren of de presentatie opslaan.

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen zelfs de inhoud van je presentatie bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties aanpassen: wanneer mensen een presentatie niet kunnen openen, kunnen ze geen wijzigingen aanbrengen.

  **Opmerking** dat wanneer je een presentatie met een wachtwoord beschermt om openen te voorkomen, het presentatiedbestand versleuteld wordt.

## Hoe een presentatie online met wachtwoord beveiligen

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop or upload your files**.

3. Selecteer het bestand dat je wilt beveiligen op je computer. 

4. Voer je gewenste wachtwoord in voor bewerkingsbeveiliging; voer je gewenste wachtwoord in voor weergavebeveiliging. 

5. Als je wilt dat gebruikers je presentatie zien als het definitieve exemplaar, vink dan het **Mark as final** selectievakje aan.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in deze formaten: 

- PPTX en PPT – Microsoft PowerPoint‑presentatie 
- ODP – OpenDocument‑presentatie 
- OTP – OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat wachtwoordbeveiliging te gebruiken om bewerkingen op presentaties te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbeveiliging instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides maakt het mogelijk om andere taken met wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeveiliging van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie wachtwoordbeveiligd is.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Vervolgens moet een gebruiker het wachtwoord invoeren om de vergrendelde presentatie te wijzigen.

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [ProtectionManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie versleutelt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Schrijfbeveiliging instellen voor een presentatie** 

Je kunt een markering toevoegen met de tekst “Do not modify” aan een presentatie. Zo kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbeveiliging de presentatie niet versleutelt. Daarom kunnen gebruikers – als ze dat willen – de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze de presentatie onder een andere naam opslaan.

Om een schrijfbeveiliging in te stellen, moet je de setWriteProtection‑methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbeveiliging voor een presentatie instelt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Een presentatie ontsleutelen; een versleutelde presentatie openen**

Aspose.Slides laat je een versleuteld bestand laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode zonder parameters aanroepen. Daarna moet je het juiste wachtwoord invoeren om de presentatie te laden. 

Deze voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of bewerken. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode aanroepen. Deze voorbeeldcode laat zien hoe je versleuteling van een presentatie verwijdert:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Schrijfbeveiliging van een presentatie verwijderen**

Je kunt Aspose.Slides gebruiken om de schrijfbeveiliging van een presentatie‑bestand te verwijderen. Zo kunnen gebruikers naar believen bewerken – en krijgen ze geen waarschuwingen wanneer ze dit doen.

Je kunt de schrijfbeveiliging van een presentatie verwijderen met de [remove_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode. Deze voorbeeldcode laat zien hoe je de schrijfbeveiliging van een presentatie verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eigenschappen van een versleutelde presentatie ophalen**

Doorgaans hebben gebruikers moeite om de documenteigenschappen van een versleutelde of wachtwoordbeveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen en toch gebruikers toegang geeft tot de eigenschappen.

**Opmerking:** Standaard worden bij het versleutelen van een presentatie door Aspose.Slides de documenteigenschappen van de presentatie ook met een wachtwoord beveiligd. Als je wilt dat de documenteigenschappen toegankelijk blijven na versleuteling, biedt Aspose.Slides precies die mogelijkheid.

Als je wilt dat gebruikers de eigenschappen van een versleutelde presentatie kunnen blijven bekijken, stel je de eigenschap `encrypt_document_properties` van [ProtectionManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) in op `False`. Deze voorbeeldcode laat zien hoe je een presentatie versleutelt terwijl je gebruikers toch toegang geeft tot de documenteigenschappen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Alleen documenteigenschappen laden van een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia's of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/)‑object aan en stel je [only_load_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/only_load_document_properties/) in op `True`. In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke documenteigenschappen.

De volgende code‑voorbeeld leest ingebouwde documenteigenschappen en geeft aangepaste documenteigenschappen weer via [Presentation.document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Lees ingebouwde documenteigenschappen.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Lijst aangepaste documenteigenschappen.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Deze workflow werkt alleen wanneer de documenteigenschappen openbaar (niet versleuteld) zijn gelaten op het moment dat de presentatie werd versleuteld. Als de documenteigenschappen versleuteld zijn, leidt het instellen van `only_load_document_properties` op `True` tot een exceptie omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde documenteigenschappen te benaderen of de volledige presentatie (inclusief dia's en andere inhoud) te laden, geef je de correcte `password`‑waarde op in [LoadOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/).

## **Controleren of een presentatie wachtwoordbeveiligd is vóór het laden**

Voordat je een presentatie laadt, wil je wellicht controleren of de presentatie niet met een wachtwoord beveiligd is. Zo kun je fouten en soortgelijke problemen vermijden die ontstaan wanneer een wachtwoordbeveiligde presentatie zonder wachtwoord wordt geladen.

Deze Python‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze wachtwoordbeveiligd is (zonder de presentatie zelf te laden):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie versleuteld is. Hiervoor kun je de eigenschap [is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) gebruiken, die `True` retourneert als de presentatie versleuteld is of `False` als deze niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je controleert of een presentatie versleuteld is:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Controleren of een presentatie schrijfbeveiligd is**

Aspose.Slides maakt het mogelijk te controleren of een presentatie schrijfbeveiligd is. Hiervoor kun je de eigenschap [is_write_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) gebruiken, die `True` retourneert als de presentatie versleuteld is of `False` als deze niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je controleert of een presentatie schrijfbeveiligd is:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt om een presentatie te beveiligen**

Je wilt misschien controleren of een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # controleer of "pass" overeenkomt met
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Het retourneert `True` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert het `False`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/nl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, inclusief op AES gebaseerde algoritmen, wat een hoog niveau van gegevensbeveiliging voor je presentaties garandeert.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het proberen te openen van een presentatie?**

Er wordt een exceptie gegooid als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie geweigerd wordt. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoordbeveiligde presentaties?**

Het versleutelen en ontsleutelen kan een lichte overhead veroorzaken tijdens openen en opslaan. In de meeste gevallen is de impact minimaal en heeft deze geen significante invloed op de totale verwerkingstijd van je presentatietaken.