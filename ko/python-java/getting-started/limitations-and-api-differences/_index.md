---
title: 제한 사항 및 API 차이점
type: docs
weight: 100
url: /ko/python-java/limitations-and-api-differences/
keywords: "노드, 파워포인트, 제한, API, 차이점"
description: "Aspose.Slides for Python via Java의 제한 사항 및 API 차이점."
---
## **알려진 버그/제한 사항**
Java 클래스가 패키지 밖(`default`)에 있으면 가져올 수 없습니다.
JVM 지원이 부족하기 때문에 JVM을 종료한 뒤 다시 시작할 수 없습니다. 또한 JVM을 여러 개 동시에 시작할 수도 없습니다.
64비트 Python과 32비트 Java를 혼용하거나 그 반대로 사용할 경우 jpype 모듈을 가져올 때 충돌이 발생합니다.

## **공용 API 차이점**
다음 목록(샘플 코드 조각 포함)은 Aspose.Slides for Java와 Aspose.Slides for Python via Java API 간의 차이점을 보여줍니다.

### **라이브러리 가져오기 (패키지 비교)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **새 Presentation 인스턴스화**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **파일 및 상수 스트리밍**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Aspose.Slides for Python via Java API가 Aspose.Slides for Java API에 비해 갖는 기타 제한 사항**

다른 제한 사항에 대한 자세한 내용은 jpype 문서를 참조하십시오:
- https://jpype.readthedocs.io/en/latest/