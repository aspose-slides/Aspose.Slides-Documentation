---
title: Biztonsági Kezelő követelmények
type: docs
weight: 190
url: /hu/java/declaration/
keywords:
- Biztonsági Kezelő
- biztonsági szabályzat
- AllPermission
- jogosultságok
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Milyen Security Manager jogosultságokra van szüksége az Aspose.Slides for Java-nak és a kódnak, amely azt meghívja, a Java 23 és korábbi verziókban, és miért nincs mit konfigurálni a Java 24 és újabb verziókban."
---
## **Áttekintés**

A Java Biztonsági Kezelő korlátozza, hogy a kód mit tehet egy biztonsági szabályzat szerint. A Java 17 elavulttá tette annak eltávolítása céljából ([JEP 411](https://openjdk.org/jeps/411)), a Java 24 pedig végleg letiltotta ([JEP 486](https://openjdk.org/jeps/486)). Ez a cikk elmagyarázza, hogy az Aspose.Slides for Java-nek mire van szüksége, amikor egy alkalmazás még a Biztonsági Kezelővel fut. Ha az alkalmazásod nem engedélyezi azt, ami az alapértelmezett, akkor nincs mit konfigurálni.

## **Java 23 és korábbiak**

Amikor egy Security Manager engedélyezve van, a biztonsági szabályzatnak meg kell adnia ezeket a jogokat az Aspose.Slides JAR fájlnak és az azt meghívó alkalmazáskódnak:

- `java.util.PropertyPermission "*", "read"`: Az Aspose.Slides rendszer tulajdonságokat olvas.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Az Aspose.Slides betűtípusfájlokat és egyéb fájlokat olvas.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Az Aspose.Slides operációs rendszer programokat indít, például a Windows‑on a `reg`‑et és a Linuxon a `fc-match`‑et.
- `java.io.FilePermission` a `write` művelettel azokhoz a mappákhoz, ahová az alkalmazásod fájlokat ment.

A jogosultságok csak a JAR fájlnak a megadása nem elegendő: a kódnak, amely az Aspose.Slides‑t hívja, szintén szüksége van rájuk. A `java.security.AllPermission` mindkettőnek a megadása is működik.

A rendszer tulajdonságok olvasásához vagy programok indításához szükséges engedély hiányában az Aspose.Slides már az első használatkor hibázik: egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektum létrehozása `ExceptionInInitializerError`‑t dob. A betűtípusfájlok olvasásához szükséges hozzáférés hiányában a prezentáció PDF‑ként való mentése a „Cannot find any fonts installed on the system” hibaüzenettel sikertelen.

## **Java 24 és újabb**

Java 24‑en és újabb verziókon a Biztonsági Kezelő nem engedélyezhető, így nincs mit megadni jogosultságként. Az Aspose.Slides az a fiók jogosultságaival fut, amely az alkalmazásodat futtatja. Az alkalmazás hozzáférésének korlátozásához az OpenJDK projekt a JDK‑n kívüli technológiákat ajánlja, például konténereket, hipervizorokat és operációs rendszer sandbox funkciókat. Lásd [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Használhatom az Aspose.Slides‑t olyan környezetben, ahol az alkalmazások szigorú Security Manager szabályzat alatt futnak?**

Csak akkor, ha a szabályzat az előbb felsorolt jogosultságokat mind az Aspose.Slides‑nek, mind a hívó kódnak megadja. Ezek magukban foglalják az összes fájl olvasását és bármely program indítását.