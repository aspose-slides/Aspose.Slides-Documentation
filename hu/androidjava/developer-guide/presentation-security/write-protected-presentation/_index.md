---
title: Írásvédett prezentációk Androidon
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/androidjava/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- jelszó a módosításhoz
- prezentáció szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó érvényesítése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állíts be, észleld, érvényesítsd és távolítsd el az írásvédelmi jelszavakat PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for Android Java segítségével."
---
## **Bevezetés**

A módosításvédelmi jelszó korlátozza a prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók a módosításvédett prezentációt jelszó nélkül betölthetik és megtekinthetik. Az alkalmazástól függően szerkeszthetik a tartalmat és más néven is menthetik, ezért a módosításvédelmet nem szabad titoktartási mechanizmusnak tekinteni.

Egy megnyitási jelszó más célt szolgál: titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. A prezentáció titkosításához vagy a megnyitási jelszó ellenőrzéséhez lásd [Jelszóval védett prezentációk](/slides/hu/androidjava/password-protected-presentation/).

A cikkben leírt munkafolyamatok a PPT és PPTX prezentációkra egyaránt vonatkoznak. A példák PPTX fájlokat használnak; PPT mentésekor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Módosításvédelem beállítása a prezentáción**

Használd az [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) metódust egy jelszó hozzárendeléséhez a prezentáció módosításához. A prezentáció mentése megőrzi a védelmi beállítást.

A következő példa módosításvédelmet állít be egy PPTX prezentáción:

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

## **Módosításvédett prezentáció betöltése**

Mivel a módosításvédelem nem titkosítja a prezentáció tartalmát, a prezentáció betöltéséhez nincs szükség jelszóra. A jelszó csak akkor releváns, amikor a védett prezentáció módosítási jogosultságának ellenőrzéséről van szó.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Ne adj meg módosításvédelmi jelszót a [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak. Ez a metódus a titkosított tartalom megnyitási jelszavát várja. Ha egy prezentációnak mindkét típusú védelem van, add meg a megnyitási jelszót a betöltéshez, a módosításvédelmi jelszót külön kezeld.

## **Módosításvédelem eltávolítása a prezentációból**

Használd az [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) metódust a módosítási korlátozás eltávolításához, majd mentse a prezentációt.

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

## **Ellenőrzés, hogy a prezentáció módosításvédett-e**

Egy fájl vizsgálatához anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt hoznál létre, hívd meg az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust, és ellenőrizd az [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) tulajdonságot. A metódus a [NullableBool](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/) típust használja, és `NullableBool.True` értékkel tér vissza, ha módosításvédelem észlelhető.

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

A [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) stream‑túlterhelése ugyanezen információt szolgáltat egy áramlásként megadott prezentáció esetén.

## **Módosításvédelmi jelszó ellenőrzése**

Használd az [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) metódust a módosítási jelszó ellenőrzéséhez anélkül, hogy a teljes prezentációt betöltenéd. Előbb ellenőrizd az [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) állapotot, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha módosításvédelem van jelen.

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

Az [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) csak a módosításvédelmi jelszót validálja. Nem ellenőrzi a megnyitási jelszót, és nem állapítja meg, hogy titkosított tartalom betölthető‑e. Ezzel szemben az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) csak a megnyitási jelszót ellenőrzi. Ha egy komplett prezentáció már be van töltve, az [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) a védelmi menedzserén keresztül biztosítja a megfelelő módosításvédelmi ellenőrzést.

Éles környezetben ne naplózd a jelszavakat, és ne helyezd őket diagnosztikai üzenetekbe. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, és tartsd a jelszavakat a memóriában csak annyira, amennyi szükséges.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval védett prezentációk](/slides/hu/androidjava/password-protected-presentation/)
- [Csak olvasható prezentációk](/slides/hu/androidjava/read-only-presentation/)
- [Digitális aláírás a PowerPoint‑ban](/slides/hu/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja‑e a módosításvédelem a prezentációt?**

Nem. A módosításvédelmi jelszó korlátozza a módosítást, de a prezentáció tartalma továbbra is betölthető és megtekinthető.

**Szükséges‑e a módosításvédelmi jelszó a prezentáció megnyitásához?**

Nem. Csak a megnyitási jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet egy prezentációnak egyszerre megnyitási és módosításvédelmi jelszója?**

Igen. Add meg a megnyitási jelszót a betöltési beállításokban a titkosított prezentáció megnyitásához, és a módosítási jogosultság kérésénél külön ellenőrizd a módosításvédelmi jelszót.