---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/python-java/system-requirements/
keywords:
- rendszerkövetelmények
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Ellenőrizze az operációs rendszer, a Python, a Java és a JPype követelményeit az Aspose.Slides for Python via Java Windows, Linux és macOS rendszereken való futtatásához."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java prezentációkat hoz létre, módosít, konvertál és renderel anélkül, hogy a Microsoft PowerPoint telepítve lenne. JPype-et használ a Java könyvtár Pythonból történő eléréséhez, ezért a környezetnek támogatnia kell a Python, Java és JPype együttes használatát.

## **Támogatott operációs rendszerek**

Az [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) a következő operációs rendszercsaládokat támogatja:

- Windows
- Linux
- macOS

Válasszon egy olyan operációs rendszerverziót, amelyet a kiválasztott Python, Java és JPype kiadásai támogatnak. A Java jelenléte önmagában nem garantálja a kompatibilitást a Python csomaggal és annak hídjával.

## **Python, Java és JPype követelmények**

| Komponens | Követelmény |
| --- | --- |
| Python | Az Aspose.Slides csomag a Python 3.7‑től 3.14‑ig terjedő verziókat deklarálja. A kiválasztott JPype kiadásnak ugyanazt a Python verziót kell támogatnia; például a [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) Python 3.8 vagy újabb verziót igényel. |
| Java | Telepítsen egy a kiválasztott JPype kiadással kompatibilis Java futtatókörnyezetet vagy JDK‑t. A jelenlegi [JPype prerequisites](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) Java 11 vagy újabb verziót határoz meg. Java 8 nem képes futtatni a JPype1 1.7.1‑et. |
| JPype | Telepítse a JPype1 csomagot a Python‑interpreteréhez, operációs rendszeréhez és CPU‑architektúrájához. |
| CPU‑architektúra | A Pythonnak és a Java Virtual Machinenek (JVM) egyező architektúrával kell rendelkeznie. Például egy 64‑bit-es Python‑interpreter egy kompatibilis 64‑bit‑JVM‑et igényel. |

Apple Siliconon a Pythonnak és a Java‑nak egyaránt ARM64‑nek vagy mindkettőnek x64‑nek kell lennie. Egy önállóan futó JVM is hibát okozhat a JPype‑on keresztüli betöltéskor, ha architektúrája eltér a Pythonétól.

Új környezethez a Python 3.12, JDK 17 és JPype1 1.7.1 megfelelő kiindulópont. Ez a kombináció az Aspose.Slides for Python via Java 26.6.0 verzióval Windowson történt ellenőrzésekor működött. Más kombinációknak a három komponens követelményeit kell teljesíteniük.

A környezet beállításához és egy működő ellenőrző példához lásd a [Installation](/slides/hu/python-java/installation/) oldalt.

## **További függőségek**

Egy kompatibilis előre lefordított JPype‑wheel nem igényel C++ fordítót. Ha a JPype‑t forrásból kell felépíteni, telepítsen egy kompatibilis C++ fordítót és a platformja által igényelt Python fejlesztői fájlokat. A [JPype installation instructions](https://jpype.readthedocs.io/en/latest/install.html) tartalmazza a build követelményeit és a hibakeresésre vonatkozó információkat.

## **GYIK**

**Szükséges-e a Microsoft PowerPoint telepítve legyen?**

Nem. Az Aspose.Slides a prezentációkat a PowerPointtól függetlenül dolgozza fel. A Python, Java és JPype továbbra is kötelező.

**Használhatok Python 3.7‑et bármely JPype kiadással?**

Nem. Bár az Aspose.Slides csomag a Python 3.7‑et is támogatja, a JPype1 1.7.1 Python 3.8 vagy újabb verziót igényel. Olyan verziókat válasszon, amelyek követelményei átfednek.

**Összekeverhetem a 32‑bit‑es Python‑t a 64‑bit‑es Java‑val?**

Nem. A JPype a JVM‑et a Python folyamatba tölti be, így a Pythonnak és a Java‑nak egyező architektúrával kell rendelkeznie. Ugyanez a követelmény az ARM64 és x64 architektúrákra vonatkozóan macOS‑on.