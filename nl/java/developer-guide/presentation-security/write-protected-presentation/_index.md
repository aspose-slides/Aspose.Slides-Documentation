---
title: Presentaties met schrijfbeveiliging in Java
linktitle: Schrijfbeveiliging
type: docs
weight: 25
url: /nl/java/write-protected-presentation/
keywords:
- schrijfbeveiliging
- PowerPoint schrijfbeveiliging
- wachtwoord om te wijzigen
- beperken bewerken van presentatie
- schrijfbeveiliging verwijderen
- wijzigingswachtwoord valideren
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Instellen, detecteren, valideren en verwijderen van schrijfbeveiligingswachtwoorden in PowerPoint PPT- en PPTX-presentaties met Aspose.Slides voor Java."
---
## **Introductie**

Een write‑protection‑wachtwoord beperkt de wijziging van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een write‑protected‑presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de applicatie kunnen ze ook de inhoud bewerken en onder een andere naam opslaan, dus write‑protection mag niet worden beschouwd als een vertrouwelijkheidsmechanisme.

Een opening‑wachtwoord heeft een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Voor het versleutelen van een presentatie of het valideren van een opening‑wachtwoord, zie [Presentaties beveiligen met wachtwoord](/slides/nl/java/password-protected-presentation/).

De werkstromen in dit artikel zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeeldbestanden gebruiken PPTX‑bestanden; bij opslaan naar PPT, gebruik de extensie `.ppt` en het bijbehorende PPT‑opslaformaat.

## **Write‑protection instellen voor een presentatie**

Gebruik [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie maakt de beschermingsinstelling permanent.

Het volgende voorbeeld stelt write‑protection in op een PPTX‑presentatie:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Write‑protected presentatie laden**

Aangezien write‑protection de presentatie‑inhoud niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beschermde presentatie te wijzigen.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Geef geen write‑protection‑wachtwoord door aan [ILoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Deze methode accepteert een opening‑wachtwoord voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, voorzie dan het opening‑wachtwoord om deze te laden en behandel het write‑protection‑wachtwoord apart.

## **Write‑protection verwijderen van een presentatie**

Gebruik [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) om de wijzigingsbeperking te verwijderen, en sla vervolgens de presentatie op.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een presentatie write‑protected is**

Om een bestand te onderzoeken zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)-instantie te maken, roep [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) aan en inspecteer [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Deze methode gebruikt [NullableBool](https://reference.aspose.com/slides/nl/java/com.aspose.slides/nullablebool/) en retourneert `NullableBool.True` wanneer write‑protection wordt gedetecteerd.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

De stream‑overload van [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) levert dezelfde informatie voor een presentatie die als stream wordt aangeleverd.

## **Write‑protection‑wachtwoord valideren**

Gebruik [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) zodat de applicatie alleen om een wachtwoord vraagt of dit valideert wanneer write‑protection aanwezig is.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) valideert alleen het write‑protection‑wachtwoord. Het valideert geen opening‑wachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Integendeel, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) valideert alleen een opening‑wachtwoord. Als een volledige presentatie al is geladen, biedt [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) de equivalente write‑protection‑controle via zijn beschermingsmanager.

Log in productie‑toepassingen geen wachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen en bewaar wachtwoorden alleen zo lang in het geheugen als nodig is.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties beveiligen met wachtwoord](/slides/nl/java/password-protected-presentation/)
- [Alleen‑lezen presentaties](/slides/nl/java/read-only-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt write‑protection een presentatie?**

Nee. Het beperkt de wijziging, maar laat de inhoud van de presentatie beschikbaar voor laden en bekijken.

**Is het write‑protection‑wachtwoord vereist om een presentatie te openen?**

Nee. Alleen een opening‑wachtwoord is vereist om versleutelde presentatiedata te laden.

**Kan een presentatie zowel een opening‑wachtwoord als een write‑protection‑wachtwoord hebben?**

Ja. Voorzie het opening‑wachtwoord via de laad‑opties om de versleutelde presentatie te openen, en valideer het write‑protection‑wachtwoord apart wanneer autorisatie voor wijziging nodig is.