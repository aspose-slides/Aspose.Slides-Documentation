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
- schrijfbescherming
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbescherming verwijderen
- PowerPoint-presentatie
- Python
- Aspose.Slides
description: "Leer hoe u moeiteloos PowerPoint- en OpenDocument-presentaties met wachtwoordbeveiliging kunt vergrendelen en ontgrendelen met Aspose.Slides voor Python via .NET. Verhoog uw productiviteit en beveilig uw presentaties met onze stapsgewijze handleiding."
---
## **Introductie**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Typisch kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen wijzigen, kun je een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie aanpassen, wijzigen of kopiëren (tenzij ze het wachtwoord invoeren). 

  In dit geval kan een gebruiker echter, zelfs zonder wachtwoord, het document openen. In deze alleen-lezen modus kan de gebruiker de inhoud of elementen—hyperlinks, animaties, effecten, enz.—in je presentatie bekijken, maar hij/zij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie mogen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze ook niet aanpassen. 
  
  **Opmerking** dat wanneer je een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentatiebestand wordt versleuteld.

## Hoe een presentatie online met wachtwoord beveiligen

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop of upload your files**.

3. Selecteer het bestand dat je op je computer wilt beveiligen met een wachtwoord. 

4. Voer je gewenste wachtwoord in voor bewerkingsbeveiliging; voer je gewenste wachtwoord in voor weergavebeveiliging. 

5. Als je wilt dat gebruikers je presentatie zien als het definitieve exemplaar, vink dan het selectievakje **Mark as final** aan.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT - Microsoft PowerPoint-presentatie 
- ODP - OpenDocument-presentatie 
- OTP - OpenDocument-presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides maakt het mogelijk om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie ophalen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord is beveiligd.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Om vervolgens de vergrendelde presentatie te wijzigen, moet een gebruiker het wachtwoord invoeren. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de `encrypt`‑methode (van [ProtectionManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de `encrypt`‑methode en gebruikt vervolgens de `save`‑methode om de nu versleutelde presentatie op te slaan. 

De volgende voorbeeldcode laat zien hoe je een presentatie versleutelt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Schrijfbescherming instellen voor een presentatie** 

Je kunt een markering “Niet wijzigen” aan een presentatie toevoegen. Op deze manier kun je gebruikers duidelijk maken dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbescherming de presentatie niet versleutelt. Gebruikers kunnen – indien ze dat willen – de presentatie wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam opslaan. 

Om een schrijfbescherming in te stellen, moet je de `setWriteProtection`‑methode gebruiken. Deze voorbeeldcode laat zien hoe je een schrijfbescherming voor een presentatie instelt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Een presentatie ontsleutelen; een versleutelde presentatie openen**

Aspose.Slides maakt het mogelijk om een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode zonder parameters aanroepen. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden. 

De volgende voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om de versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [remove_encryption](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling van een presentatie verwijdert:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Schrijfbescherming van een presentatie verwijderen**

Je kunt met Aspose.Slides de schrijfbescherming van een presentatietbestand verwijderen. Op deze manier kunnen gebruikers de presentatie naar wens wijzigen en krijgen ze geen waarschuwingen meer bij dergelijke handelingen.

Je kunt de schrijfbescherming van een presentatie verwijderen met de [remove_write_protection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/)‑methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie verwijdert:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **De eigenschappen van een versleutelde presentatie ophalen**

Gebruikers hebben vaak moeite om de documenteigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen met een wachtwoord terwijl je de mogelijkheid behoudt voor gebruikers om de eigenschappen van die presentatie te bekijken.

**Opmerking** dat wanneer Aspose.Slides een presentatie versleutelt, de documenteigenschappen van de presentatie standaard ook met een wachtwoord worden beveiligd. Als je echter wilt dat de eigenschappen van de presentatie toegankelijk blijven (zelfs nadat de presentatie is versleuteld), biedt Aspose.Slides precies die mogelijkheid. 

Als je wilt dat gebruikers de mogelijkheid behouden om de eigenschappen van een door jou versleutelde presentatie te bekijken, kun je de eigenschap [EncryptDocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) instellen op `True`. Deze voorbeeldcode laat zien hoe je een presentatie versleutelt en tegelijkertijd de toegang tot de documenteigenschappen mogelijk maakt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Controleren of een presentatie met een wachtwoord is beveiligd voordat deze wordt geladen**

Voordat je een presentatie laadt, wil je mogelijk controleren of de presentatie niet met een wachtwoord is beveiligd. Op deze manier kun je fouten en soortgelijke problemen vermijden, die optreden wanneer een met een wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze Python‑code laat zien hoe je een presentatie kunt onderzoeken om te bepalen of deze met een wachtwoord is beveiligd (zonder de presentatie zelf te laden):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Om deze taak uit te voeren, kun je de eigenschap [is_encrypted](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) gebruiken, die `True` retourneert als de presentatie versleuteld is of `False` als de presentatie niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeschermd is. Om deze taak uit te voeren, kun je de eigenschap [is_write_protected](https://reference.aspose.com/slides/nl/python-net/aspose.slides/protectionmanager/) gebruiken, die `True` retourneert als de presentatie versleuteld is of `False` als de presentatie niet versleuteld is. 

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeschermd is:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt om een presentatie te beveiligen**

Je wilt misschien nagaan en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord valideert:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # controleer of "pass" overeenkomt met
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Hij retourneert `True` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert hij `False`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een verkeerd wachtwoord wordt ingevoerd bij het openen van een presentatie?**

Er wordt een uitzondering gegooid als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is de impact minimaal en beïnvloedt het de totale verwerkingstijd van je presentatietaken niet aanzienlijk.