---
title: Protection en écriture des présentations sur Android
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/androidjava/write-protected-presentation/
keywords:
- protection en écriture
- protection en écriture PowerPoint
- mot de passe pour modifier
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l'aide d'Aspose.Slides pour Android via Java."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d’une présentation mais n’encrypte pas son contenu. Les utilisateurs peuvent charger et visualiser une présentation protégée en écriture sans le mot de passe. Selon l’application, ils peuvent également modifier le contenu et l’enregistrer sous un autre nom, de sorte que la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d’ouverture sert un but différent : il crypte la présentation et est requis pour charger son contenu. Pour crypter une présentation ou valider un mot de passe d’ouverture, consultez [Protéger les présentations par mot de passe](/slides/fr/androidjava/password-protected-presentation/).

Les flux de travail de cet article s’appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l’enregistrement au format PPT, utilisez l’extension `.ppt` et le format d’enregistrement PPT correspondant.

## **Définir la protection en écriture sur une présentation**

Utilisez [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) pour attribuer un mot de passe de modification d’une présentation. L’enregistrement de la présentation conserve le paramètre de protection.

L’exemple suivant définit la protection en écriture sur une présentation PPTX :

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

## **Charger une présentation protégée en écriture**

Comme la protection en écriture n’encrypte pas le contenu de la présentation, aucun mot de passe n’est requis pour charger la présentation. Le mot de passe n’est pertinent que lors de la validation de l’autorisation de modifier la présentation protégée.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Ne transmettez pas un mot de passe de protection en écriture à [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Cette méthode accepte un mot de passe d’ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d’ouverture pour la charger et traitez séparément le mot de passe de protection en écriture.

## **Supprimer la protection en écriture d’une présentation**

Utilisez [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) pour supprimer la restriction de modification, puis enregistrez la présentation.

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

## **Vérifier si une présentation est protégée en écriture**

Pour inspecter un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), appelez [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) et examinez [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). La méthode utilise [NullableBool](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/nullablebool/) et renvoie `NullableBool.True` lorsque la protection en écriture est détectée.

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

La surcharge de flux de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fournit les mêmes informations pour une présentation fournie sous forme de flux.

## **Valider un mot de passe de protection en écriture**

Utilisez [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d’abord [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) afin que l’application demande ou valide un mot de passe uniquement lorsque la protection en écriture est présente.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d’ouverture ni ne détermine si le contenu chiffré peut être chargé. En revanche, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) ne valide qu’un mot de passe d’ouverture. Si une présentation complète a déjà été chargée, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) fournit la même vérification de protection en écriture via son gestionnaire de protection.

Dans les applications en production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et ne conservez les mots de passe en mémoire que le temps nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations par mot de passe](/slides/fr/androidjava/password-protected-presentation/)
- [Présentations en lecture seule](/slides/fr/androidjava/read-only-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre-t-elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est-il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d’ouverture est requis pour charger le contenu chiffré d’une présentation.

**Une présentation peut-elle avoir à la fois un mot de passe d’ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d’ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l’autorisation de modification est requise.