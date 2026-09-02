---
title: Írásvédett bemutatók JavaScriptben
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/nodejs-java/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- módosítási jelszó
- bemutató szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Állítsa be, észlelje, ellenőrizze és távolítsa el az írásvédelmi jelszavakat a PowerPoint PPT és PPTX bemutatókban az Aspose.Slides for Node.js használatával Java-on keresztül."
---
## **Bevezetés**

A írásvédelmi jelszó korlátozza a bemutató módosítását, de nem titkosítja a tartalmát. A felhasználók írásvédett bemutatót betölthetik és megtekinthetik jelszó nélkül. Az alkalmazástól függően szerkeszthetik is a tartalmat, és más néven menthetik, ezért az írásvédelmet nem szabad titoktartási mechanizmusnak tekinteni.

A nyitó jelszó más célra szolgál: titkosítja a bemutatót, és a tartalom betöltéséhez szükséges. A bemutató titkosításához vagy a nyitó jelszó ellenőrzéséhez lásd [Jelszóval Védett Bemutatók](/slides/hu/nodejs-java/password-protected-presentation/).

A cikkben leírt munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák PPTX fájlokat használnak; PPT formátumba mentéskor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Írásvédelem beállítása egy bemutatón**

Az [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) metódust használja jelszó hozzárendeléséhez a bemutató módosításához. A bemutató mentése megőrzi a védelmi beállítást.

Az alábbi példa írásvédelmet állít be egy PPTX bemutatón:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Írásvédett Bemutató betöltése**

Mivel az írásvédelem nem titkosítja a bemutató tartalmát, a bemutató betöltéséhez nem szükséges jelszó. A jelszó csak akkor releváns, ha a védett bemutató módosítási jogosultságát ellenőrizzük.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Ne adjon át írásvédelmi jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusnak. Ez a metódus a titkosított tartalom nyitó jelszavát fogadja. Ha egy bemutatónak mindkét típusú védelem van, akkor a nyitó jelszót adja meg a betöltéshez, az írásvédelmi jelszót külön kezelje.

## **Írásvédelem eltávolítása egy bemutatóból**

Az [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) metódust használja a módosítási korlátozás eltávolításához, majd mentse a bemutatót.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ellenőrzés, hogy a bemutató írásvédett-e**

A fájl ellenőrzéséhez anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt hozna létre, hívja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, és ellenőrizze a [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) tulajdonságot. A metódus a [NullableBool](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/nullablebool/) típust használja, és `NullableBool.True` értéket ad vissza, ha írásvédelem van.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Az áramlatalapú [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) metódus ugyanezt az információt nyújtja egy Node.js olvasható áramlásként biztosított bemutatóhoz.

## **Írásvédelmi jelszó ellenőrzése**

Használja a [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) metódust a módosítási jelszó ellenőrzéséhez a teljes bemutató betöltése nélkül. Először ellenőrizze a [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) tulajdonságot, hogy az alkalmazás csak írásvédelem esetén kérjen vagy ellenőrizzen jelszót.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) csak az írásvédelmi jelszót ellenőrzi. Nem ellenőrzi a nyitó jelszót, és nem dönt arról, hogy a titkosított tartalom betölthető-e. Ezzel szemben a [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkPassword) csak a nyitó jelszót ellenőrzi. Ha a teljes bemutató már be van töltve, a [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) a védelmi menedzserén keresztül biztosítja az azonos írásvédelmi ellenőrzést.

Éles alkalmazásokban ne naplózza a jelszavakat, és ne szerepeltessen őket diagnosztikai üzenetekben. Kerülje a felesleges ismételt ellenőrzési kísérleteket, és a jelszavakat csak a szükséges ideig tartsa memóriában.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval Védett Bemutatók](/slides/hu/nodejs-java/password-protected-presentation/)
- [Csak Olvasható Bemutatók](/slides/hu/nodejs-java/read-only-presentation/)
- [Digitális Aláírás PowerPointban](/slides/hu/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja-e az írásvédelem a bemutatót?**

Nem. Korlátozza a módosítást, de a bemutató tartalma elérhető betöltésre és megtekintésre.

**Szükséges-e az írásvédelmi jelszó a bemutató megnyitásához?**

Nem. Csak a nyitó jelszó szükséges a titkosított bemutató betöltéséhez.

**Lehet-e egy bemutatónak egyszerre nyitó jelszava és írásvédelmi jelszava is?**

Igen. A nyitó jelszót a betöltési beállításokkal kell megadni a titkosított bemutató megnyitásához, az írásvédelmi jelszót külön kell ellenőrizni, ha módosítási jogosultságra van szükség.