---
title: Declaração
type: docs
weight: 60
url: /pt/java/artifact-classifier-change/
keywords:
- classificador Aspose.Slides
- classificador de artefato
- usar Aspose.Slides
- instalação Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aspose.Slides for Java agora usa o classificador jdk8 em vez de jdk16. Saiba por que e como atualizar suas dependências."
---
## **Alteração do Classificador de Artefato de `jdk16` para `jdk8`**

A partir da versão **26.10**, alteramos o classificador usado em nossos artefatos publicados de **`jdk16`** (Java 6) para **`jdk8`** (Java 8).

### **O que mudou**

| | Antes | Depois |
|---|---|---|
| Classificador | `jdk16` | `jdk8` |
| Versão mínima do Java | Java 1.6 | Java 8 |

**Antes:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Depois:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Por que fizemos esta mudança**

Após revisão interna, decidimos **descontinuar o suporte a versões mais antigas do Java** que não agregavam valor e dificultavam a manutenção. O Java 8 foi selecionado como a nova base segura para todos os consumidores.

Como parte disso, o classificador foi atualizado para refletir a versão mínima realmente suportada. Também nos alinhamos com a convenção de nomenclatura atual da Oracle, onde o produto é oficialmente chamado de **JDK 8** (em vez do formato legado `1.8`).

### **O que você precisa fazer**

1. **Atualize o classificador** nas suas declarações de dependência de `jdk16` para `jdk8`.

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

2. **Verifique se seu ambiente de tempo de execução** está com Java 8 ou superior.

3. **Atualize quaisquer arquivos de bloqueio** ou caches de dependência que fixem o classificador antigo.

### **Nota de Migração: jdk16 e jdk8**

A partir da versão 26.10​, os classificadores jdk16 e jdk8 fornecerão JARs compatíveis com Java 8 (construídos com compatibilidade source/target definida para Java 8).

 - `jdk16` → continua publicado para compatibilidade retroativa (integrações existentes).
 - `jdk8` → introduzido como o novo classificador preferencial para ambientes Java 8.

⚠️ Nota: Esta fase de publicação dupla está programada para terminar em 31 de março de 2027​. Após essa data, o classificador jdk16 será descontinuado e apenas o jdk8 será suportado.

### **Notas de Compatibilidade**

- O classificador `jdk16` **não será mais publicado** após **31 de março de 2027**.
- Se você ainda precisar de suporte ao Java 1.6, permaneça na linha de versão principal anterior até poder migrar.

### **Precisa de ajuda?**

Se encontrar problemas durante a migração, entre em contato com [Suporte da Aspose](https://forum.aspose.com/) para obter mais assistência.