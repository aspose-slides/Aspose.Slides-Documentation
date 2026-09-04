---
title: 제한 사항 및 API 차이점
type: docs
weight: 100
url: /ko/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- API 차이점
- Python
- Java
- JPype
- JVM 제한 사항
- PowerPoint
description: "Aspose.Slides for Java와 Python via Java 간의 JVM 제한 사항 및 API 차이점에 대해 배우십시오. 여기에는 가져오기, 리소스 정리 및 파일 처리 등이 포함됩니다."
---
## **개요**

Aspose.Slides for Python via Java은 JPype를 사용하여 Python에서 Java 라이브러리에 접근합니다. 아래 예제는 두 API에서 패키지 가져오기, 프레젠테이션 생성 및 파일 처리 방식을 비교합니다.

## **알려진 제한 사항**

- **JVM 수명 주기:** JPype는 Python 프로세스당 하나의 JVM만 지원합니다. JVM을 종료한 후에는 동일한 프로세스에서 다시 시작할 수 없습니다. 한 번 시작하고 이후 프레젠테이션 작업에 재사용하세요.
- **아키텍처 호환성:** Python과 Java는 동일한 아키텍처여야 합니다. 자세한 내용은 [시스템 요구 사항](/slides/ko/python-java/system-requirements/#python-java-and-jpype-requirements) 을 참고하세요.

자세한 제한 사항 및 Java 상호 운용성에 대해서는 [JPype 사용자 가이드](https://jpype.readthedocs.io/en/latest/userguide.html)를 확인하십시오.

## **공개 API 차이점**

아래 Java와 Python 예제를 비교하십시오. Python via Java 멤버 상세 내용은 [API 참조](/slides/ko/python-java/api-reference/) 를 참고하세요.

### **라이브러리 가져오기**

Java는 `com.aspose.slides`에서 클래스를 가져옵니다. Python에서는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행 중일 때 `asposeslides.api`에서 클래스를 가져옵니다. 이미 실행 중인 JVM을 다시 시작하지 않도록 [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) 를 사용하십시오.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Python 예제는 Python 프로세스가 종료될 때까지 JVM을 실행 상태로 유지합니다. 노트북에서는 셀 간에 활성 JVM을 재사용하십시오. 이미 종료된 경우 Java 객체를 다시 사용하기 전에 노트북 커널을 재시작해야 합니다.
{{% /alert %}}

### **프레젠테이션 만들기**

Java는 `new` 키워드를 사용하고, Python은 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 직접 호출합니다. `finally` 블록에서 [Presentation.dispose](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#dispose) 로 프레젠테이션 리소스를 해제하십시오.

두 예제 모두 빈 프레젠테이션을 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 와 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#pptx) 로 저장합니다.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **파일 읽기 및 형식 상수 사용**

Java는 Java 입력 스트림으로 프레젠테이션을 로드할 수 있습니다. Python에서는 파일을 바이너리 데이터로 읽고 해당 바이트 배열을 [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#createpresentationfrombytes) 에 전달합니다. Python 파일 객체는 Java 입력 스트림이 아닙니다.

아래 예제는 작업 디렉터리에 `presentation.pptx` 파일이 존재하고, 결과를 `result.pptx` 로 저장한다는 전제하에 작성되었습니다. 두 예제 모두 입력 파일을 닫고 프레젠테이션 리소스를 해제합니다. Python 예제는 전체 입력 파일을 메모리로 읽어들입니다.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**각 프레젠테이션마다 JVM을 재시작해야 합니까?**

아니요. JVM을 계속 실행하고 필요에 따라 프레젠테이션 객체를 생성 및 해제하십시오. JVM을 종료하면 동일한 Python 프로세스에서 더 이상 Java 작업을 수행할 수 없습니다.

**파일 경로에서 직접 프레젠테이션을 열 수 있나요?**

예. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 생성자는 파일 경로를 받아들입니다. 프레젠테이션 데이터가 이미 Python 바이트 형태로 존재하는 경우 바이트 기반 도우미를 사용하십시오.

**Java 예제를 Python으로 번역할 때 형식 상수 이름을 바꿔야 하나요?**

아니요. 예를 들어, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#pptx) 은 두 API 모두 동일한 철자와 대소문자를 사용합니다.