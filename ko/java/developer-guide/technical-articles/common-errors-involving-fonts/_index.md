---
title: Linux에서 폰트와 관련된 일반적인 예외 및 오류
type: docs
weight: 200
url: /ko/java/common-errors-involving-fonts/
keywords: "폰트 예외, 폰트 오류, Linux, Java, Aspose.Slides for Java"
description: "Linux에서의 폰트 예외 및 오류"
---
## **개요**

Linux에서 Aspose.Slides를 사용할 때 Java 프로세스가 필수 폰트 폴더나 임시 디렉터리에 접근하지 못하거나 시스템에 폰트가 설치되지 않았거나 fontconfig 또는 libfreetype과 같은 필수 시스템 라이브러리가 누락된 경우 폰트 관련 문제가 발생할 수 있습니다.

이 문서는 Linux에서 폰트와 관련된 일반적인 오류와 예외를 설명하고 해결 방법을 제공합니다. 폰트 및 TEMP 디렉터리 접근 권한 확인, 필요한 폰트 및 라이브러리 설치, 그리고 시스템 전체에 설치하지 않고 `FontsLoader`를 사용해 폰트를 로드하는 방법을 안내합니다.

## **Linux에서 코드 실행 시 텍스트 또는 이미지(EMF 또는 WMF) 누락**

다음과 같은 제한이 있는 시스템에서 이 문제가 발생합니다:

1. 폰트가 설치되지 않았거나 Java 프로세스가 폰트 폴더에 접근할 수 없는 경우
2. TEMP 디렉터리에 접근할 수 없는 경우

### **해결 방법**

TEMP 디렉터리와 폰트 폴더에 대한 접근 권한이 부여되었는지 확인하십시오. 

{{% alert color="warning" %}}

환경이나 보안 정책에 의해 폴더 접근 권한을 부여할 수 없는 경우도 있습니다. 다음 해결 방법을 시도해 보세요: 

{{% /alert %}}

**우회 방법**

필요한 폰트를 시스템 전체에 설치하지 않고 로드하려면 [FontsLoader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsLoader)를 사용하십시오:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP 디렉터리에 접근할 수 없는 경우, Java용 TEMP 디렉터리를 다른 경로로 지정하는 코드를 사용하십시오:
```
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

## **예외: InvalidOperationException: 시스템에 설치된 폰트를 찾을 수 없습니다**

이 예외는 다음 상황에서 발생합니다.

1) Java 프로세스가 폰트 폴더에 접근할 수 없는 경우  
2) 폰트가 전혀 설치되지 않은 경우

### **해결 방법**

1. Java 프로세스가 폰트 폴더에 접근할 수 있는지 확인하십시오.

2. 일부 폰트를 설치하거나 [FontsLoader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsLoader)를 사용하십시오.

3. 폰트를 설치하십시오.

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

   * [FontsLoader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FontsLoader) 사용: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **예외: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

이 예외는 fontconfig와 폰트가 설치되지 않은 Linux 시스템에서 발생합니다. 

### **해결 방법**

fontconfig를 설치하십시오:

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

또한 일부 open-jdk 버전(예: **alpine JDK**)은 **설치된 폰트**가 필요합니다.

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

## **예외: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

이 예외는 libfreetype 라이브러리가 누락된 Linux 시스템에서 발생합니다. 

### **해결 방법**

libfreetype와 fontconfig를 설치하십시오:

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

폰트를 설치하거나 FontsLoader를 사용하는 것을 잊지 마세요.

{{% /alert %}}