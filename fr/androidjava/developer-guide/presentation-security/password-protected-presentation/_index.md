---
title: Protéger les présentations par mot de passe sur Android
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/androidjava/password-protected-presentation/
keywords:
  - présentation protégée par mot de passe
  - mot de passe d'ouverture
  - chiffrer PowerPoint
  - déchiffrer PowerPoint
  - valider le mot de passe de la présentation
  - vérifier le mot de passe de la présentation
  - ouvrir une présentation chiffrée
  - supprimer le chiffrement
  - PowerPoint
  - PPT
  - PPTX
  - présentation
  - Android
  - Java
  - Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer des présentations PowerPoint PPT et PPTX protégées par mot de passe avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est nécessaire pour charger et afficher le contenu de la présentation, ainsi cette protection assure la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu ni n'empêche le chargement de la présentation. Pour gérer les mots de passe permettant de modifier les présentations, consultez [Write-Protect Presentations](/slides/fr/androidjava/write-protected-presentation/).

Les flux de travail ci-dessous s'appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur des fichiers ou des flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [IProtectionManager.encrypt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) pour attribuer un mot de passe d'ouverture. Puis utilisez [IPresentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) pour enregistrer la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :

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

## **Charger une présentation chiffrée**

Définissez [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) sur le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Travaillez avec la présentation déchiffrée.
} finally {
    presentation.dispose();
}
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--), puis enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.

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

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) pour obtenir [IPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/) sans créer d'instance complète de présentation. Vérifiez [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) avant de demander ou de valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flux de travail par chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), puis charge la présentation complète :

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

### **Flux de travail par flux**

La surcharge de flux de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) offre le même flux de travail. Réinitialisez la position d'un flux recherchable avant de charger la présentation complète à partir de ce flux.

L'exemple suivant utilise un fichier PPT :

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

### **Valeurs de retour de checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) retourne `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Il retourne `false` dans chacun de ces cas :

- Le mot de passe est incorrect.
- La présentation ne possède pas de mot de passe d'ouverture.
- Le mot de passe fourni est `null` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, examinez [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez `IPresentationInfo.isPasswordProtected` comme indiqué ci-dessus.

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

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.
{{% /alert %}}

## **Protéger par mot de passe une présentation en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléchargez la présentation.
1. Saisissez un mot de passe pour la protection en lecture.
1. Optionnellement, saisissez un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations en écriture](/slides/fr/androidjava/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est nécessaire pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si la protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de présentation.

**Les flux de travail de vérification de mot de passe prennent-ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation de mot de passe basées sur le chemin de fichier ou le flux se comportent de la même façon pour les présentations PPT et PPTX.