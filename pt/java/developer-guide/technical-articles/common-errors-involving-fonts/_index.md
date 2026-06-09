---
title: Exceções e Erros Comuns Relacionados a Fontes no Linux
type: docs
weight: 200
url: /pt/java/common-errors-involving-fonts/
keywords: "Exceção de fonte, Erro de fonte, Linux, Java, Aspose.Slides for Java"
description: "Exceções e erros de fonte no Linux"
---
## **Visão geral**

Quando o Aspose.Slides é usado no Linux, podem ocorrer problemas relacionados a fontes se o processo Java não puder acessar as pastas de fontes necessárias ou o diretório temporário, se nenhuma fonte estiver instalada no sistema ou se bibliotecas de sistema necessárias, como fontconfig ou libfreetype, estiverem ausentes.

Este artigo descreve erros e exceções comuns relacionados a fontes no Linux e fornece soluções para resolvê-los. Ele explica como verificar o acesso aos diretórios de fontes e TEMP, instalar as fontes e bibliotecas necessárias e usar `FontsLoader` para carregar fontes sem instalá‑las em todo o sistema.

## **Texto ou imagens ausentes (EMF ou WMF) quando o código é executado no Linux**

Este problema ocorre em sistemas com restrições nos seguintes casos:

1. Quando não há fontes instaladas ou quando a pasta de fontes para o processo java não pode ser acessada
2. Quando o diretório TEMP não pode ser acessado.

### **Solução**

Verifique e confirme que o acesso ao diretório TEMP e à pasta de fontes foi concedido. 

{{% alert color="warning" %}}

Em alguns casos, pode ser impossível conceder acesso às pastas devido a restrições impostas pelo ambiente ou por uma política de segurança. Experimente estas soluções alternativas: 

{{% /alert %}}

**Solução alternativa**

Use [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsLoader) para carregar as fontes necessárias sem instalá‑las:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Se o diretório TEMP não puder ser acessado, use este código para especificar outro diretório como TEMP para o Java:
```java
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Exceção: InvalidOperationException: Não foi possível encontrar fontes instaladas no sistema**

Esta exceção ocorre quando

1) o processo Java não pode acessar a pasta de fontes  
2) nenhuma fonte foi instalada.

### **Solução**

1. Verifique e confirme que o acesso à pasta de fontes para o processo Java foi concedido.

2. Instale algumas fontes ou use [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsLoader).

3. Instale fontes.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * Using [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Exceção: NoClassDefFoundError: Não foi possível inicializar a classe com.aspose.slides.internal.ey.this**

Esta exceção ocorre em um sistema Linux que não possui fontconfig e fontes. 

### **Solução**

Instale fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Além disso, algumas versões do open-jdk (por exemplo, **alpine JDK**) também **requerem fontes instaladas**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Exceção: UnsatisfiedLinkError: libfreetype.so.6: Não foi possível abrir o arquivo de objeto compartilhado: Nenhum arquivo ou diretório encontrado**

Esta exceção ocorre em um sistema Linux que não possui a biblioteca libfreetype. 

### **Solução**

Instale libfreetype e fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 

Não se esqueça de instalar fontes ou usar FontsLoader.

{{% /alert %}}