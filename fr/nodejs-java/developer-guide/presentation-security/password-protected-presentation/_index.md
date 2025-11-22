---
title: "Présentation protégée par mot de passe"
type: docs
weight: 20
url: /fr/nodejs-java/password-protected-presentation/
keywords: "Verrouiller une présentation PowerPoint en JavaScript"
description: "Verrouiller une présentation PowerPoint. PowerPoint protégé par mot de passe en JavaScript"
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe d’une présentation ?**
Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour lever ces restrictions, il faut saisir le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (sauf si elles fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut consulter le contenu ou les éléments — hyperliens, animations, effets, etc. — de votre présentation, mais il ne peut pas copier les éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation (sauf si elles fournissent le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de la présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Drop or upload your files**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe souhaité pour la protection en modification ; saisissez le mot de passe souhaité pour la protection en lecture.

5. Si vous voulez que les utilisateurs voient votre présentation comme une copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode `encrypt` (de [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager)) afin de définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode `encrypt` et utilisez la méthode `save` pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Définir une protection en écriture sur une présentation**

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils modifient la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Ce code d’exemple montre comment définir une protection en écriture sur une présentation :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Déchiffrer une présentation ; ouvrir une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) sans paramètres. Vous devrez ensuite saisir le bon mot de passe pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation :
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // travailler avec la présentation déchiffrée
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Supprimer le chiffrement ; désactiver la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restriction.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—et ils ne recevront aucun avertissement lors de ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs ont du mal à récupérer les propriétés d’un document lorsqu’une présentation est chiffrée ou protégée par mot de passe. Aspose.Slides propose cependant un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Remarque** que lorsqu’Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après le chiffrement), Aspose.Slides vous le permet.

Si vous voulez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez définir la propriété [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) sur `true`. Ce code d’exemple montre comment chiffrer une présentation tout en offrant aux utilisateurs la possibilité d’accéder à ses propriétés de document :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code JavaScript montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe (sans charger la présentation) :
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) qui renvoie `true` si la présentation est chiffrée ou `false` si elle ne l’est pas.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé pour protéger une présentation**

Il se peut que vous souhaitiez vérifier et confirmer qu’un mot de passe particulier a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // vérifier si "pass" correspond
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Il renvoie `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il renvoie `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Digital Signature in PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous informant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des implications de performance lors du travail avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.