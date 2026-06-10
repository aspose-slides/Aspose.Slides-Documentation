---
title: Telepítés
type: docs
weight: 70
url: /hu/cpp/installation/
keywords:
- telepítés Aspose.Slides
- letöltés Aspose.Slides
- használat Aspose.Slides
- Aspose.Slides telepítése
- Windows
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan telepítheti gyorsan az Aspose.Slides for C++-t. Lépésről-lépésre útmutató, rendszerkövetelmények és kódminták — kezdje el még ma a PowerPoint-prezentációk használatát!"
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan telepíthető az Aspose.Slides Windows rendszeren. A NuGet‑alapú telepítésre összpontosít, és bemutatja, hogyan lehet a könyvtárat hozzáadni egy Visual Studio projekthez a NuGet Package Manager vagy a Package Manager Console használatával Windowson. Emellett ismerteti, hogyan frissíthető a csomag és hogyan telepíthetők előzetes kiadások, ha szükséges.

## **Windows**
A NuGet biztosítja a legegyszerűbb módot az Aspose API‑k C++‑ra történő letöltésére és telepítésére PC‑ken. 

### **Opció egy: Az Aspose.Slides for C++ telepítése vagy frissítése a NuGet Package Managerből**

1. Nyissa meg a Microsoft Visual Studio‑t. 
2. Hozzon létre egy egyszerű konzolalkalmazást. Vagy megnyithatja a kedvenc projektjét. 
3. Navigáljon a **Tools** > **NuGet package manager** menüpontra. 
4. **Browse** alatt írja be a *Aspose.Slides.Cpp* szöveget a mezőbe. 

![todo:image_alt_text](installation_1.png)

3. Kattintson a szükséges **Aspose.Slides.Cpp** verzióra, majd kattintson a **Install** gombra. 
   * Ha frissíteni szeretné az Aspose.Slides‑t (ami azt jelenti, hogy már telepítve van), akkor kattintson a **Update** gombra. 

A kiválasztott API letöltődik, és hivatkozásként kerül a projektbe.

### **Opció 2: Az Aspose.Slides telepítése vagy frissítése a Package Manager Console használatával**

A [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) hivatkozásához a package manager console használatával tegye a következőt:

1. Nyissa meg a megoldást/projektet a Visual Studio‑ban.

1. Navigáljon a **Tools** > **NuGet Package Manager** > **Package Manager Console** menüpontra. 

   A Package Manager Console megnyílik. 

![todo:image_alt_text](installation_2.png)

4. Írja be ezt a parancsot: `Install-Package Aspose.Slides.Cpp` 
> Ha az x86 verziót szeretné telepíteni, használja az Aspose.Slides.Cpp.x86 csomagot: `Install-Package Aspose.Slides.Cpp.x86`

5. Nyomja meg az Enter billentyűt.

   A legújabb teljes kiadás települ az alkalmazásba. 

   * Alternatív megoldásként hozzáadhatja a `-prerelease` utótagot a parancshoz, hogy a legújabb kiadás (javításokkal együtt) is települjön. 

![todo:image_alt_text](installation_3.png)

​	Ha a letöltés befejeződik, néhány megerősítő üzenetet kell látnia.  

![todo:image_alt_text](installation_4.png)

Ha nem ismeri az [Aspose EULA](https://about.aspose.com/legal/eula) felhasználási feltételeit, akkor érdemes elolvasnia az URL‑ben hivatkozott licencet. 

A Package Manager Console‑ban futtathatja az `Update-Package Aspose.Slides.Cpp` parancsot az Aspose.Slides csomag frissítéseinek ellenőrzéséhez. A frissítések (ha vannak) automatikusan települnek. A `-prerelease` utótaggal is frissítheti a legújabb kiadást.

### **Include és lib mappák használata**
1. [Töltse le](https://downloads.aspose.com/slides/hu/cpp) az Aspose.Slides for C++ legújabb verzióját.
2. Csomagolja ki a mappát a termelési környezetbe.
3. Az Aspose.Slides for C++ használatához hivatkozzon a projektjében az Include és lib mappákra.

## **GYIK**

**Van ingyenes verzió vagy próbaverzió korlátozással?**

Igen, alapértelmezés szerint az Aspose.Slides értékelő módban fut, amely vízjeleket helyez el, és egyéb korlátozásokkal is járhat. A korlátozások eltávolításához érvényes [licencet](/slides/hu/cpp/licensing/) kell alkalmazni.