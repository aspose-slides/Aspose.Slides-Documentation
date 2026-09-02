---
title: Írásvédett prezentációk Java-ban
linktitle: Írásvédelem
type: docs
weight: 25
url: /hu/java/write-protected-presentation/
keywords:
- írásvédelem
- PowerPoint írásvédelem
- módosítási jelszó
- prezentáció szerkesztésének korlátozása
- írásvédelem eltávolítása
- módosítási jelszó ellenőrzése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Állítsd be, észleld, ellenőrizd és távolítsd el az írásvédelmi jelszavakat PowerPoint PPT és PPTX prezentációkban az Aspose.Slides for Java segítségével."
---
## **Bevezetés**

Egy írásvédelem jelszó korlátozza a prezentáció módosítását, de nem titkosítja annak tartalmát. A felhasználók jelszó nélkül betölthetik és megtekinthetik az írásvédett prezentációt. Az alkalmazástól függően szerkeszthetik a tartalmat, és más néven menthetik, ezért az írásvédelmet nem szabad titoktartási mechanizmusnak tekinteni.

A megnyitási jelszó más célra szolgál: titkosítja a prezentációt, és a tartalom betöltéséhez szükséges. A prezentáció titkosításához vagy a megnyitási jelszó ellenőrzéséhez lásd a [Jelszóval védett prezentációk](/slides/hu/java/password-protected-presentation/) oldalát.

A cikkben található munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák PPTX fájlokat használnak; PPT mentéskor a `.ppt` kiterjesztést és a megfelelő PPT mentési formátumot kell használni.

## **Írásvédelem beállítása egy prezentációhoz**

Használd a [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) metódust, hogy jelszót rendelj a prezentáció módosításához. A prezentáció mentése elmenti a védelmi beállítást.

Az alábbi példa írásvédelmet állít be egy PPTX prezentáción:

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

## **Írásvédett prezentáció betöltése**

Mivel az írásvédelem nem titkosítja a prezentáció tartalmát, a betöltéshez nincs szükség jelszóra. A jelszó csak akkor releváns, amikor a védett prezentáció módosítási engedélyét ellenőrizni kell.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Ne add át az írásvédelmi jelszót a [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak. Ez a metódus a titkosított tartalom megnyitási jelszavát fogadja. Ha egy prezentáció mindkét típusú védelmet tartalmazza, add meg a megnyitási jelszót a betöltéshez, és kezeld külön az írásvédelmi jelszót.

## **Írásvédelem eltávolítása egy prezentációról**

Használd a [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) metódust az írási korlátozás eltávolításához, majd mentsd a prezentációt.

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

## **Az írásvédelem ellenőrzése egy prezentációban**

Egy fájl vizsgálatához anélkül, hogy teljes [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt hoznál létre, hívd a [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust, és ellenőrizd az [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) tulajdonságot. A metódus [NullableBool](https://reference.aspose.com/slides/hu/java/com.aspose.slides/nullablebool/) értékkel tér vissza, és `NullableBool.True` értéket ad, ha írásvédelem észlelhető.

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

Az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) beolvasó (stream) túlterhelése ugyanazt az információt adja egy áramlásként (stream) átadott prezentációra.

## **Írásvédelmi jelszó ellenőrzése**

Használd az [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) metódust, hogy a módosítási jelszót ellenőrizd a teljes prezentáció betöltése nélkül. Először ellenőrizd az [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) állapotot, hogy az alkalmazás csak akkor kérjen vagy ellenőrizzen jelszót, ha írásvédelem van jelen.

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

Az [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) csak az írásvédelmi jelszót ellenőrzi. Nem ellenőriz egy megnyitási jelszót, és nem állapítja meg, hogy titkosított tartalom betölthető-e. Ezzel szemben az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) csak egy megnyitási jelszót ellenőriz. Ha egy teljes prezentáció már be van töltve, akkor az [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) biztosítja az írásvédelmi ellenőrzés ekvivalensét a védelmi manageren keresztül.

Éles alkalmazásokban ne naplózd a jelszavakat, és ne tüntesd fel őket diagnosztikai üzenetekben. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, és csak annyi ideig tartsd a jelszavakat a memóriában, ameddig szükséges.

{{% alert color="info" title="Lásd még" %}}
- [Jelszóval védett prezentációk](/slides/hu/java/password-protected-presentation/)
- [Csak olvasható prezentációk](/slides/hu/java/read-only-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Titkosítja az írásvédelem a prezentációt?**

Nem. A módosítást korlátozza, de a prezentáció tartalma továbbra is betölthető és megtekinthető.

**Szükséges az írásvédelmi jelszó a prezentáció megnyitásához?**

Nem. Csak a megnyitási jelszó szükséges a titkosított prezentáció tartalmának betöltéséhez.

**Lehet egy prezentációnak egyszerre megnyitási és írásvédelmi jelszava is?**

Igen. Add meg a megnyitási jelszót a betöltési beállításokban a titkosított prezentáció megnyitásához, és a módosítási jogosultság kérésekor külön ellenőrizd az írásvédelmi jelszót.