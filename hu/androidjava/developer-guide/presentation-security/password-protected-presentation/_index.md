---
title: Jelszóval védett prezentációk Androidon
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/androidjava/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszó ellenőrzése
- prezentáció jelszavának ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Titkosíts, észleld, ellenőrizd, nyisd meg, valamint fejtsd vissza a jelszóval védett PowerPoint PPT és PPTX prezentációkat az Androidra készült Aspose.Slides segítségével Java nyelven."
---
## **Áttekintés**

A nyitó jelszó titkosítja a prezentációt. A helyes jelszóra van szükség a prezentáció tartalmának betöltéséhez és megtekintéséhez, így ez a védelem bizalmasságot biztosít.

A nyitó jelszó különbözik a írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséhez lásd a [Write-Protect Presentations](/slides/hu/androidjava/write-protected-presentation/).

Az alábbi munkafolyamatok PPT és PPTX prezentációkra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl alapú és az adatfolyam alapú viselkedés fontos.

## **Prezentáció titkosítása nyitó jelszóval**

Használd az [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metódust nyitó jelszó megadásához. Ezután az [IPresentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódussal mentheted el a titkosított prezentációt.

Az alábbi példa egy PPTX prezentációt titkosít:

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

## **Titkosított prezentáció betöltése**

Állítsd be az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) értékét a nyitó jelszóra, majd a betöltéskor add át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztálynak. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Dolgozz a visszafejtett prezentációval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása egy prezentációból**

Töltsd be a prezentációt a nyitó jelszavával, hívd meg az [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) metódust, és mentse el az eredményt. A mentett prezentáció ezután jelszó nélkül is betölthető.

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

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használd az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) lekéréséhez anélkül, hogy teljes prezentációs példányt hoznál létre. Ellenőrizd a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) értékét, mielőtt jelszót kérnél vagy ellenőriznél. Ha védelem van, ellenőrizd a megadott értéket az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) metódussal.

### **Fájl-útvonal munkafolyamat**

Az alábbi példa egy PPTX fájl nyitó jelszavát ellenőrzi, a hitelesített értéket átadja az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak, majd betölti a teljes prezentációt:

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

### **Adatfolyam munkafolyamat**

Az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) adatfolyam‑túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsd vissza egy kereshető adatfolyam pozícióját, mielőtt a teljes prezentációt betöltenéd ebből az adatfolyamból.

Az alábbi példa egy PPT fájlt használ:

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

### **checkPassword visszatérési értékek**

Az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) `true` értéket ad csak akkor, ha a prezentációnak nyitó jelszója van, és a megadott jelszó helyes. `false` értéket ad a következő esetekben:

- A jelszó helytelen.
- A prezentációnak nincs nyitó jelszava.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX prezentációk esetén is ugyanaz.

## **Ellenőrizd, hogy egy betöltött prezentáció titkosított-e**

A prezentáció helyes jelszóval történő betöltése után vizsgáld meg az [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) értékét, hogy megerősítsd, a forrás prezentáció titkosított volt. A nyitó jelszavas védelem betöltés előtti észleléséhez használd a `IPresentationInfo.isPasswordProtected` metódust, ahogy fentebb bemutattuk.

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

## **Biztonsági ajánlások**

{{% alert color="warning" title="Biztonság" %}}
Ne naplózd a nyitó jelszavakat, és ne tüntesd fel őket diagnosztikai üzenetekben. Kerüld a felesleges, ismételt ellenőrzési kísérleteket, tartsd a jelszavakat a memóriában csak a szükséges ideig, és használd újra a sikeres ellenőrzés eredményét, amikor azonnal betöltöd a prezentációt.
{{% /alert %}}

## **Prezentáció jelszóval való védelme online**

1. Nyisd meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válaszd ki vagy töltsd fel a prezentációt.
3. Adj meg egy jelszót a megtekintési védelemhez.
4. Opcionálisan adj meg egy külön jelszót a szerkesztési védelemhez.
5. Alkalmazd a védelmet, és töltsd le a kapott fájlt.

{{% alert color="info" title="Lásd még" %}}
- [Prezentációk írásvédelme](/slides/hu/androidjava/write-protected-presentation/)
- [Digitális aláírás a PowerPointban](/slides/hu/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a prezentációt, és a tartalom betöltéséhez szükséges. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetem a nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezd meg a prezentáció információit, ellenőrizd, hogy van-e nyitó jelszóval védve, és a teljes prezentáció példány létrehozása előtt ellenőrizd a jelszót.

**A jelszó-ellenőrző munkafolyamatok támogatják a PPT és PPTX formátumokat is?**

Igen. A fájl-útvonal és adatfolyam alapú jelszó-érzékelés és ellenőrzés ugyanúgy működik PPT és PPTX prezentációk esetén.