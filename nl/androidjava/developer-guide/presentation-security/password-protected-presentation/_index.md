---
title: Presentaties beveiligen met wachtwoord op Android
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/androidjava/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- Android
- Java
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT- en PPTX‑presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en te bekijken, waardoor deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt bewerking, maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Om wachtwoorden voor het bewerken van presentaties te beheren, zie [Write-Protect Presentations](/slides/nl/androidjava/write-protected-presentation/).

De onderstaande workflows zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestands‑ en stream‑gebaseerde gedrag belangrijk is.

## **Versleutel een presentatie met een openingswachtwoord**

Gebruik [IProtectionManager.encrypt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Houd documenteigenschappen openbaar**

Standaard omvat Aspose.Slides documenteigenschappen bij de versleuteling van een presentatie. De methode [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) regelt dit gedrag onafhankelijk van de versleuteling van de slide‑inhoud. Geef `false` door voordat u [IProtectionManager.encrypt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) aanroept wanneer een indexerings‑, classificatie‑, zoek‑ of document‑beheersysteem metadata moet lezen zonder het openingswachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` doorgeven aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) maakt de slides, masters, lay‑outs, vormen, media of andere presentatie‑inhoud niet openbaar. Het beïnvloedt alleen documenteigenschappen. Zie [Manage Presentation Properties](/slides/nl/androidjava/presentation-properties/) om die eigenschappen te lezen zonder de versleutelde inhoud te laden.

## **Laad een versleutelde presentatie**

Stel [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Werk met de ontsleutelde presentatie.
} finally {
    presentation.dispose();
}
```

## **Verwijder versleuteling uit een presentatie**

Laad de presentatie met het openingswachtwoord, roep [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Valideer een openingswachtwoord vóór het laden**

Gebruik [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) om [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/) te verkrijgen zonder een volledige presentatie‑instantie te maken. Controleer [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) voordat u een wachtwoord aanvraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Bestandspad‑workflow**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), en laadt vervolgens de volledige presentatie:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Stream‑workflow**

De stream‑overload van [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) biedt dezelfde workflow. Reset de positie van een zoekbare stream voordat u de volledige presentatie vanuit die stream laadt.

Het volgende voorbeeld gebruikt een PPT‑bestand:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Return‑waarden van checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleer of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het correcte wachtwoord, inspecteer [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) om te bevestigen dat de bronpresentatie versleuteld was. Om openings‑wachtwoordbescherming vóór het laden te detecteren, gebruik `IPresentationInfo.isPasswordProtected` zoals hierboven weergegeven.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Security" %}}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden in het geheugen alleen zolang nodig, en hergebruik een geslaagd validatie‑resultaat bij het direct laden van de presentatie.

Openbare documenteigenschappen kunnen namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen, zelfs wanneer de presentatie‑inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn die alleen wordt genomen wanneer systemen het bestand moeten indexeren, classificeren, doorzoeken of beheren zonder een openingswachtwoord.
{{% /alert %}}

## **Wachtwoord‑beveilig een presentatie online**

1. Open de [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock) applicatie.
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergavebeveiliging.
4. Voer eventueel een apart wachtwoord in voor bewerkingsbeveiliging.
5. Pas de beveiliging toe en download het resulterende bestand.

{{% alert color="info" title="See also" %}}
- [Presentaties met schrijfbescherming](/slides/nl/androidjava/write-protected-presentation/)
- [Digitale ondertekening in PowerPoint](/slides/nl/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Veelgestelde vragen**

**Wat is het verschil tussen een openingswachtwoord en een schrijfbeschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt bewerking zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle slides te laden?**

Ja. Verkrijg presentatiedetails, controleer of bescherming met een openingswachtwoord aanwezig is, en valideer het wachtwoord voordat u een volledige presentaties‑instantie maakt.

**Kan een applicatie metadata lezen zonder het openingswachtwoord?**

Ja, maar alleen wanneer de presentatie is versleuteld met de encryptie van documenteigenschappen uitgeschakeld. De applicatie moet dan de alleen‑documenteigenschappen‑laadmodus gebruiken die wordt beschreven in [Manage Presentation Properties](/slides/nl/androidjava/presentation-properties/).

**Ondersteunen de wachtwoord‑controleworkflows zowel PPT als PPTX?**

Ja. Wachtwoorddetectie en -validatie op basis van bestandspad en stream werken hetzelfde voor PPT‑ en PPTX‑presentaties.