---
title: Rendszerkövetelmények
type: docs
weight: 80
url: /hu/java/system-requirements/
keywords:
- rendszerkövetelmények
- operációs rendszer
- telepítés
- függőségek
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java rendszerkövetelményeit. Biztosítsa a PowerPoint és az OpenDocument zökkenőmentes támogatását Windows, Linux és macOS rendszereken."
---
## **Áttekintés**
Az Aspose.Slides for Java nem igényli a Microsoft PowerPoint telepítését, mivel az Aspose.Slides önmagában egy Microsoft PowerPoint dokumentum létrehozó, konvertáló, oldalelrendező és renderelő motor.
## **Támogatott operációs rendszerek**
Az Aspose.Slides for Java bármely 32 bites vagy 64 bites operációs rendszert támogat, amely futtatja a Java futtatókörnyezetet, többek között, de nem kizárólag:
### **Windows**
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2008 Server (x64, x86)
- Microsoft Windows 2012 Server (x64, x86)
- Microsoft Windows 2012 R2 Server (x64, x86)
- Microsoft Windows 2016 Server (x64, x86)
- Microsoft Windows 2019 Server (x64, x86)
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)


### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS és mások)

### **Mac**
- Mac OS X

## **Támogatott Java verziók**
Az Aspose.Slides for Java támogatja a J2SE 6.0 (Java 1.6) és újabb verziókat.

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére a konverziókhoz és a rendereléshez?**

Nem, a PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/java/create-presentation/), módosításhoz, [konvertáláshoz](/slides/hu/java/convert-presentation/) és a [rendereléshez](/slides/hu/java/convert-powerpoint-to-png/) prezentációkhoz.

**Milyen betűtípusokra van szükség a helyes rendereléshez?**

A gyakorlatban a prezentációban használt betűtípusoknak vagy a megfelelő [helyettesítőknek](/slides/hu/java/font-substitution/) kell rendelkezésre állniuk. A Linux/macOS rendszereken a konzisztens renderelés érdekében ajánlott gyakori betűcsomagokat telepíteni.

**Miért jelenik meg egy egyedi betűtípus fallback vagy hiányzó szövegként Linuxon?**

Ha a betűtípusfájlban ellentmondásos vagy sérült névtábla-bejegyzések vannak, a Linux betűtípus-illesztő réteg (FreeType/fontconfig) hibás bejegyzést választhat, ami miatt a betűtípus feloldása nem sikerül. Egy javított névtábla-bejegyzésekkel rendelkező betűtípus verziójának használata vagy egy konzisztens helyettesítő telepítése megoldja a problémát.