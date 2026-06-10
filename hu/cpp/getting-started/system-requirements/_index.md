---
title: Rendszerkövetelmények
type: docs
weight: 80
url: /hu/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ rendszerkövetelményeit. Biztosítsa a zökkenőmentes PowerPoint és OpenDocument támogatást Windows, Linux és macOS rendszerekhez."
---
## **Bevezetés**

Az Aspose.Slides nem igényli a Microsoft PowerPoint telepítését, mivel az Aspose.Slides egy önálló Microsoft PowerPoint dokumentumkészítő, konvertáló, oldalelrendezési és megjelenítési motor.

## **Támogatott operációs rendszerek**
Az Aspose.Slides for C++ egy natív C++ könyvtár. Az Aspose.Slides for C++ támogatja az alábbi 64 bites és 32 bites operációs rendszereket és platformokat:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 vagy újabb.
- CentOS 8 vagy újabb.
- Fedora 24 vagy újabb.
- És más Linux x86_64 glibc 2.23 vagy újabb verzióval.

### **macOS**
- macOS Monterey 12.1 vagy újabb.

## **Fejlesztői környezetek**
Az Aspose.Slides for C++ használható Windows, Linux vagy macOS alkalmazások fejlesztésekor.

### **Windows**
- Microsoft Visual Studio 2017 vagy későbbi.
- CMake 3.18 vagy későbbi.

### **Linux**
- Clang 3.9 vagy későbbi.
- GCC 6.1 vagy későbbi.
- CMake 3.18 vagy későbbi.

### **macOS**
- Xcode 13.4 vagy későbbi.

## **FAQ**

**Szükségem van a Microsoft PowerPoint telepítésére a konvertáláshoz és megjelenítéshez?**

Nem, a PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/cpp/create-presentation/), módosításhoz, [konvertáláshoz](/slides/hu/cpp/convert-presentation/) és a [megjelenítéshez](/slides/hu/cpp/convert-powerpoint-to-png/) prezentációkhoz.

**Milyen betűkészletekre van szükség a helyes megjelenítéshez?**

Gyakorlatilag a prezentációban használt betűkészleteknek vagy megfelelő [helyettesítőknek](/slides/hu/cpp/font-substitution/) kell rendelkezésre állniuk. A Linux/macOS rendszereken a következetes megjelenítés érdekében ajánlott általános betűkészlet-csomagokat telepíteni.

**Miért jelenik meg egy egyedi betűkészlet helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűkészlet fájlban inkonzisztens vagy sérült name-table bejegyzések vannak, a Linux betűkészlet-illesztő (FreeType/fontconfig) érvénytelen rekordot választhat, ami miatt a betűkészlet nem található. Egy javított name-table rekordokkal rendelkező betűkészlet verzió használata vagy egy konzisztens helyettesítő telepítése megoldja a problémát.