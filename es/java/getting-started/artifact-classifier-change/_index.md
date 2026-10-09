---
title: Cambio del clasificador de artefactos
type: docs
weight: 60
url: /es/java/artifact-classifier-change/
keywords:
- clasificador Aspose.Slides
- clasificador de artefacto
- uso Aspose.Slides
- instalación de Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aspose.Slides para Java ahora usa el clasificador jdk8 en lugar de jdk16. Conozca por qué y cómo actualizar sus dependencias."
---
## **Cambio del clasificador de artefactos de `jdk16` a `jdk8`**

A partir de la versión **26.10**, hemos cambiado el clasificador utilizado en nuestros artefactos publicados de **`jdk16`** (Java 6) a **`jdk8`** (Java 8).

### **Qué cambió**

| | Antes | Después |
|---|---|---|
| Clasificador | `jdk16` | `jdk8` |
| Versión mínima de Java | Java 1.6 | Java 8 |

**Antes:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Después:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Por qué hicimos este cambio**

Tras una revisión interna, decidimos **eliminar el soporte para versiones antiguas de Java** que ya no aportaban valor y obstaculizaban activamente el mantenimiento. Java 8 se seleccionó como la nueva base segura para todos los consumidores.

Como parte de esto, el clasificador se actualizó para reflejar la versión mínima real admitida. También nos alineamos con la convención de nombres actual de Oracle, donde el producto se denomina oficialmente **JDK 8** (en lugar del formato heredado `1.8`).

### **Qué necesitas hacer**

1. **Actualiza el clasificador** en tus declaraciones de dependencias de `jdk16` a `jdk8`.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Verifica que tu entorno de ejecución** sea Java 8 o superior.

3. **Actualiza cualquier archivo de bloqueo** o cachés de dependencias que fijen el clasificador antiguo.

### **Nota de migración: jdk16 y jdk8**

A partir de la versión 26.10​, ambos clasificadores jdk16 y jdk8 proporcionarán JARs compatibles con Java 8 (creados con la compatibilidad de source/target configurada a Java 8).

 - `jdk16` → continúa publicándose por compatibilidad retroactiva (integraciones existentes).
 - `jdk8` → se introduce como el nuevo clasificador preferido para entornos Java 8.

⚠️ Nota: Esta fase de publicación dual está programada para finalizar el 31 de marzo de 2027​. Después de esa fecha, el clasificador jdk16 será retirado y sólo se soportará jdk8.

### **Notas de compatibilidad**

- El clasificador `jdk16` **ya no se publica** después del **31 de marzo de 2027**.
- Si aún necesitas soporte para Java 1.6, por favor permanece en la línea de versiones mayor anterior hasta que puedas migrar.

### **¿Necesitas ayuda?**

Si encuentras problemas durante la migración, por favor contacta con [soporte de Aspose](https://forum.aspose.com/) para obtener ayuda adicional.